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

    // [HttpPost]
    // public async Task<IActionResult> PostPrescription(CancellationToken cancellationToken, [FromBody] CreatePrescription createPrescription)
    // {
    //     Console.WriteLine(createPrescription.Medicaments.First().IdMedicament);
    //     Console.WriteLine(createPrescription.Medicaments.First().Name);
    //     Console.WriteLine(createPrescription.Patient.FirstName);
    //     Console.WriteLine(createPrescription.Patient.LastName);
    //     return Ok();
    // }

    /*[HttpPost]
    public async Task<IActionResult> CreatePrescription(Prescription prescription, CancellationToken cancellationToken)
    {
        var newprescription = new Prescription
        {
            IdPrescription = prescription.IdPrescription,
            Date = prescription.Date,
            DueDate = prescription.DueDate,
            IdDoctor = prescription.IdDoctor,
            Doctor = prescription.Doctor,
            IdPatient = prescription.IdPatient,
            Patient = prescription.Patient,
            Prescription_Medicaments = prescription.Prescription_Medicaments,
        };
        
        await _dbContext.Prescriptions.AddAsync(newprescription, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Ok(prescription);
    }*/
    [HttpPost]
    public async Task<IActionResult> CreatePrescription(CreatePrescription createPrescription, CancellationToken cancellationToken)
    {
        var doctor = new Doctor
        {
            IdDoctor = createPrescription.Doctor.IdDoctor,
            FirstName = createPrescription.Doctor.FirstName,
            LastName = createPrescription.Doctor.LastName,
            Email = createPrescription.Doctor.Email,
        };
        var patient = new Patient
        {
            IdPatient = createPrescription.Patient.IdPatient,
            FirstName = createPrescription.Patient.FirstName,
            LastName = createPrescription.Patient.LastName,
            Birthdate = createPrescription.Patient.Birthdate,
        };
        
        var prescriptionMedicaments = createPrescription.Medicaments?.Select(m => new Prescription_Medicament
        {
            IdMedicament = m.IdMedicament,
            Medicament = new Medicament
            {
                IdMedicament = m.IdMedicament,
                Name = m.Name,
                Description = m.Description,
                Type = m.Type
            },
            Dose = createPrescription.Dose,
            Details = createPrescription.Details
        }).ToList() ?? new List<Prescription_Medicament>();


        var prescription = new Prescription
        {
            Date = createPrescription.Date,
            DueDate = createPrescription.DueDate,
            Doctor = doctor,
            Patient = patient,
            Prescription_Medicaments = prescriptionMedicaments
        };
        
        
        await _dbContext.Prescriptions.AddAsync(prescription, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        
        return Ok("Prescription created");
    }
}