using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShepherdsPies.Data;

namespace ShepherdsPies.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToppingController : ControllerBase
{
    private ShepherdsPiesDbContext _dbContext;

    public ToppingController(ShepherdsPiesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    //[Authorize]
    public IActionResult GetToppings()
    {
        return Ok(_dbContext.Toppings
            .ToList());
    }

    [HttpGet("pizza{id}")]
    //[Authorize]
    public IActionResult GetToppingsForPizza(int id)
    {
        return Ok(_dbContext.PizzaToppings
            .Include(pt => pt.Topping)
            .Where(pt => pt.PizzaId == id)
            .ToList());
    }
}