using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShepherdsPies.Data;

namespace ShepherdsPies.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SauceController : ControllerBase
{
    private ShepherdsPiesDbContext _dbContext;

    public SauceController(ShepherdsPiesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetSauces()
    {
        return Ok(_dbContext.Sauces
            .ToList());
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetSauce(int id)
    {
        return Ok(_dbContext.Sauces
            .SingleOrDefault(s => s.Id == id));
    }
}