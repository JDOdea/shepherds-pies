using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShepherdsPies.Data;

namespace ShepherdsPies.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SizeController : ControllerBase
{
    private ShepherdsPiesDbContext _dbContext;

    public SizeController(ShepherdsPiesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetSizes()
    {
        return Ok(_dbContext.Sizes
            .ToList());
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetSize(int id)
    {
        return Ok(_dbContext.Sizes
            .SingleOrDefault(s => s.Id == id));
    }
}