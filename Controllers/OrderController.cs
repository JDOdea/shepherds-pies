using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShepherdsPies.Data;
using ShepherdsPies.Models;

namespace ShepherdsPies.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private ShepherdsPiesDbContext _dbContext;

    public OrderController(ShepherdsPiesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    //[Authorize]
    public IActionResult GetOrders()
    {
        return Ok(_dbContext.Orders
            .Include(o => o.Employee)
            .Include(o => o.Driver)
            .Include(o => o.Pizzas)
            .ThenInclude(p => p.Size)
            .Include(o => o.Pizzas)
            .ThenInclude(p => p.PizzaToppings)
            .ThenInclude(pt => pt.Topping)
            .OrderBy(o => o.OrderDate)
            .ToList());
    }

    [HttpGet("newest")]
    //[Authorize]
    public IActionResult GetByNewest()
    {
        return Ok(_dbContext.Orders
            .Include(o => o.Employee)
            .Include(o => o.Driver)
            .Include(o => o.Pizzas)
            .ThenInclude(p => p.Size)
            .Include(o => o.Pizzas)
            .ThenInclude(p => p.PizzaToppings)
            .ThenInclude(pt => pt.Topping)
            .OrderByDescending(o => o.OrderDate)
            .ToList());
    }

    [HttpGet("{id}")]
    //[Authorize]
    public IActionResult GetById(int id)
    {
        Order foundOrder = _dbContext.Orders.SingleOrDefault(o => o.Id == id);
        if (foundOrder != null)
        {
            return Ok(_dbContext.Orders
                .Include(o => o.Employee)
                .Include(o => o.Driver)
                .Include(o => o.Pizzas)
                .ThenInclude(p => p.Size)
                .Include(o => o.Pizzas)
                .ThenInclude(p => p.Cheese)
                .Include(o => o.Pizzas)
                .ThenInclude(p => p.Sauce)
                .Include(o => o.Pizzas)
                .ThenInclude(p => p.PizzaToppings)
                .ThenInclude(pt => pt.Topping)
                .SingleOrDefault(o => o.Id == id));
        }

        return NotFound();
    }
}