using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShepherdsPies.Data;

namespace ShepherdsPies.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CheeseController : ControllerBase
{
    private ShepherdsPiesDbContext _dbContext;

    public CheeseController(ShepherdsPiesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    //[Authorize]
    public IActionResult GetCheeses()
    {
        return Ok(_dbContext.Cheeses
            .ToList());
    }

    [HttpGet("{id}")]
    //[Authorize]
    public IActionResult GetCheese(int id)
    {
        return Ok(_dbContext.Cheeses
            .SingleOrDefault(c => c.Id == id));
    }
}