using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShepherdsPies.Data;

namespace ShepherdsPies.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    private ShepherdsPiesDbContext _dbContext;

    public PizzaController(ShepherdsPiesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetPizzas()
    {
        return Ok(_dbContext.Pizzas
            .Include(p => p.Size)
            .Include(p => p.Cheese)
            .Include(p => p.Sauce)
            .Include(p => p.PizzaToppings)
            .ThenInclude(pt => pt.Topping)
            .ToList());
    }
}