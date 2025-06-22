using Kolokwium.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NurseriesController : ControllerBase
{
    private readonly DatabaseContext _dbContext;

    public NurseriesController(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{id}/batches")]
    public async Task<IActionResult> GetNurseryBatches(int id, CancellationToken cancellationToken)
    {
        var nursery = await _dbContext.Nurseries
            .Include(n => n.SeedlingBatches)
            .ThenInclude(b => b.Species)
            .Include(n => n.SeedlingBatches)
            .ThenInclude(b => b.Responsible)
            .ThenInclude(r => r.Employee)
            .FirstOrDefaultAsync(n => n.NurseryId == id, cancellationToken);
        if (nursery == null)
        {
            return NotFound();
        }

        var response = new NurseryBatchesResponseDto
        {
            NurseryId = nursery.NurseryId,
            Name = nursery.Name,
            EstablishedDate = nursery.EstablishedDate,
            Batches = nursery.SeedlingBatches?.Select(b => new BatchDto
            {
                BatchId = b.BatchId,
                Quantity = b.Quantity,
                SownDate = b.SownDate,
                ReadyDate = b.ReadyDate,
                Species = new SpeciesDto
                {
                    LatinName = b.Species.LatinName,
                    GrowthTimeInYears = b.Species.GrowthTimeInYears
                },
                Responsible = b.Responsible?.Select(r => new ResponsibleDto
                {
                    FirstName = r.Employee.FirstName,
                    LastName = r.Employee.LastName,
                    Role = r.Role
                }).ToList() ?? new List<ResponsibleDto>()
            }).ToList() ?? new List<BatchDto>()
        };

        return Ok(response);
    }
}