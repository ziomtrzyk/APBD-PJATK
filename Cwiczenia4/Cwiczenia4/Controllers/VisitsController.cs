using Cwiczenia4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetVisits()
    {
        return Ok(DataStore._visits);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetVisits(int id)
    {
        if(DataStore._animals.All(x => x.Id != id))
            return NotFound();
        var visits = DataStore._visits.Where(x => x.Id == id);
        return Ok(visits);
    }
    [HttpPost]
    public IActionResult InsertVisit(Visit visit)
    {
        if(DataStore._animals.Any(x => x.Id != visit.AnimalId))
            return NotFound();
        DataStore._visits.Add(visit);
        return Ok(DataStore._visits);
    }
}