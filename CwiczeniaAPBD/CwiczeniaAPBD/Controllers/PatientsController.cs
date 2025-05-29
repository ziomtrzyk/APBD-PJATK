using CwiczeniaAPBD.Data;
using CwiczeniaAPBD.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CwiczeniaAPBD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly DatabaseContext _dbContext;

    public PatientsController(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{patientId}")]
    public async Task<ActionResult> GetPatients(int patientId, CancellationToken cancellationToken)
    {
        var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.IdPatient == patientId, cancellationToken);

        if (patient == null)
        {
            return NotFound("Patient not found");
        }
        
        var prescriptions = await _dbContext.Prescriptions
            .Where(pr => pr.IdPatient == patientId)
            .ToListAsync(cancellationToken);
            
        var prescriptionsId = await _dbContext.Prescriptions
            .Where(pr => pr.IdPatient == patientId)
            .Select(pr => pr.IdPrescription)
            .ToListAsync(cancellationToken);

        var prescriptionMedicaments = await _dbContext.Prescription_Medicaments
            .Where(pm => prescriptionsId.Contains(pm.IdPrescription))
            .Select(pm => pm.IdMedicament)
            .ToListAsync(cancellationToken);
        
        var medicaments = await _dbContext.Medicaments
            .Where(m => prescriptionMedicaments.Contains(m.IdMedicament))
            .ToListAsync(cancellationToken);
        
        ReturnPatient rp = new ReturnPatient(patient, prescriptions, medicaments);
        
        Console.Write("============================ "+rp.Patient);
        return Ok(rp);
    }
    
}