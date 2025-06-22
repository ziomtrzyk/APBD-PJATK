using Kolokwium.DTOS;
using Kolokwium.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BatchesController : ControllerBase
{
    private readonly DatabaseContext _dbContext;

    public BatchesController(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBatch(CreateBatchRequestDto request, CancellationToken cancellationToken)
    {

        if (string.IsNullOrEmpty(request.Species))
        {
            return BadRequest("No species");
        }

        if (string.IsNullOrEmpty(request.Nursery))
        {
            return BadRequest("No nursery");
        }
        
        var species = await _dbContext.Tree_Species
            .FirstOrDefaultAsync(s => s.LatinName == request.Species, cancellationToken);
        
        if (species == null)
        {
            return BadRequest("No spieces");
        }
        
        var nursery = await _dbContext.Nurseries
            .FirstOrDefaultAsync(n => n.Name == request.Nursery, cancellationToken);
        
        if (nursery == null)
        {
            return BadRequest("No nursery");
        }
        
        var employeeIds = request.Responsible.Select(r => r.EmployeeId).ToList();
        var existingEmployees = await _dbContext.Employees
            .Where(e => employeeIds.Contains(e.EmployeeId))
            .Select(e => e.EmployeeId)
            .ToListAsync(cancellationToken);

        var missingEmployees = employeeIds.Except(existingEmployees).ToList();
        if (missingEmployees.Any())
        {
            return BadRequest($"Employee do not exist");
        }
        var newBatch = new Seedling_Batch
        {
            Quantity = request.Quantity,
            SownDate = DateTime.Now,
            ReadyDate = DateTime.Now.AddYears(species.GrowthTimeInYears),
            SpeciesId = species.SpeciesId,
            NurseryId = nursery.NurseryId
        };

        
        await _dbContext.Seedling_Batches.AddAsync(newBatch, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        var responsibleEntries = request.Responsible.Select(r => new Responsible
        {
            BatchId = newBatch.BatchId,
            EmployeeId = r.EmployeeId,
            Role = r.Role
        }).ToList();

        await _dbContext.Responsibles.AddRangeAsync(responsibleEntries, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Ok(new { BatchId = newBatch.BatchId });
    }
}