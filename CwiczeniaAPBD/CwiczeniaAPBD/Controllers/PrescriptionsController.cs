using System.Text.Json;
using System.Text.Json.Serialization;
using CwiczeniaAPBD.Data;
using CwiczeniaAPBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CwiczeniaAPBD.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly DatabaseContext _dbContext;

    public PrescriptionsController(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    public async Task<IActionResult> GetAsyc(CancellationToken cancellationToken)
    {
        var data = await _dbContext.Prescriptions.ToListAsync(cancellationToken);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Prescription_Medicament prescription_medicament,
        CancellationToken cancellationToken)
    {

        var pm = new Prescription_Medicament
        {
            IdMedicament = prescription_medicament.IdMedicament,
            Prescription = prescription_medicament.Prescription,
            Dose = prescription_medicament.Dose,
            Details = prescription_medicament.Details,
        };

        var data = await _dbContext.Prescription_Medicaments.ToListAsync(cancellationToken);
        
        //sprawdzenie czy istnieje IdMedicament
        if(data.All(x => x.IdMedicament != prescription_medicament.IdMedicament))
            return BadRequest("Medicament doesnt exist");
        
        if (prescription_medicament.Prescription.DueDate <= prescription_medicament.Prescription.Date)
            return BadRequest("Due date cannot be earlier than prescription date");
        
        
        await _dbContext.Prescription_Medicaments.AddAsync(pm, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Ok("Added Prescription_Medicament");
    }
}