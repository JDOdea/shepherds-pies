using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
    [Authorize]
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
    [Authorize]
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

    [HttpPost]
    [Authorize]
    public IActionResult CreateOrder(Order order)
    {
        try
        {
            foreach (var p in order.Pizzas)
            {
                p.Size = _dbContext.Sizes.SingleOrDefault(s => s.Id == p.SizeId);
                p.Cheese = _dbContext.Cheeses.SingleOrDefault(c => c.Id == p.CheeseId);
                p.Sauce = _dbContext.Sauces.SingleOrDefault(s => s.Id == p.SauceId);
                foreach (var t in p.PizzaToppings)
                {
                    t.Topping = _dbContext.Toppings.SingleOrDefault(top => top.Id == t.ToppingId);
                }
            }
            order.OrderDate = DateTime.Now;

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return Created($"/api/order/{order.Id}", order);
        }
        catch (DbUpdateException)
        {
            return BadRequest("Invalid data submitted");
        }
    }

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult EditOrder(int id, Order updatedOrder)
    {
        Order order = _dbContext.Orders.SingleOrDefault(o => o.Id == id);

        if (order != null) 
        {
            updatedOrder.Employee = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == updatedOrder.EmployeeId);
            updatedOrder.Driver = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == updatedOrder.DriverId);

            foreach (var p in updatedOrder.Pizzas)
            {
                p.Size = _dbContext.Sizes.SingleOrDefault(s => s.Id == p.SizeId);
                p.Cheese = _dbContext.Cheeses.SingleOrDefault(c => c.Id == p.CheeseId);
                p.Sauce = _dbContext.Sauces.SingleOrDefault(s => s.Id == p.SauceId);
                foreach (var t in p.PizzaToppings)
                {
                    t.Topping = _dbContext.Toppings.SingleOrDefault(top => top.Id == t.ToppingId);
                }
            }

            order.EmployeeId = updatedOrder.EmployeeId;
            order.Employee = updatedOrder.Employee;
            order.TableNumber = updatedOrder.TableNumber;
            order.DriverId = updatedOrder.DriverId;
            order.Driver = updatedOrder.Driver;
            order.Tipped = updatedOrder.Tipped;
            order.Pizzas = updatedOrder.Pizzas;

            _dbContext.SaveChanges();

            return NoContent();
        }

        return NotFound();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult DeleteOrder(int id)
    {
        Order foundOrder = _dbContext.Orders.SingleOrDefault(o => o.Id == id);
        if (foundOrder != null)
        {
            _dbContext.Orders.Remove(foundOrder);
            _dbContext.SaveChanges();
            return NoContent();
        }

        return NotFound();
    }
}