using CwiczeniaAPBD.Data;
using CwiczeniaAPBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CwiczeniaAPBD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly DatabaseContext _dbContext;
    
    public DoctorsController(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    public async Task<IActionResult> GetAsyc(CancellationToken cancellationToken)
    {
        //var data = await _dbContext.Prescriptions.ToListAsync(cancellationToken);
        var doctors = await _dbContext.Doctors
            .OrderBy(s => s.LastName)
            .ToListAsync(cancellationToken);
        return Ok(doctors);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsyc(CancellationToken cancellationToken, Doctor doctor)
    {

        var newdoctor = new Doctor
        {
            IdDoctor = doctor.IdDoctor,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Email = doctor.Email,
        };
        
        await _dbContext.Doctors.AddAsync(newdoctor, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Ok(doctor);
    }
    
}