using CwiczeniaAPBD.Data;
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
}