using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ShepherdsPies.Models;
using Microsoft.AspNetCore.Identity;

namespace ShepherdsPies.Data;
public class ShepherdsPiesDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    
    public DbSet<Order> Orders { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Cheese> Cheeses { get; set; }
    public DbSet<Sauce> Sauces { get; set; }
    public DbSet<PizzaTopping> PizzaToppings { get; set; }
    public DbSet<Topping> Toppings { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }

    public ShepherdsPiesDbContext(DbContextOptions<ShepherdsPiesDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[] 
        {
            new IdentityUser {Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", UserName = "Administrator", Email = "admina@strator.comx", PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])},
            new IdentityUser {Id = "5b795ef4-89bd-4de6-b6e1-6bb3dc469242", UserName = "jdfitz", Email = "jdfitz@gmail.com", PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])},
            new IdentityUser {Id = "e53af84d-c3d0-4db8-9a6a-680985b82553", UserName = "greg", Email = "greg@gmail.com", PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])},
            new IdentityUser {Id = "6245ffde-88da-4745-bd81-32943de1fa00", UserName = "jbarton", Email = "jbarton@gmail.com", PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])},
            new IdentityUser {Id = "8fe414ed-22f8-4dd5-8cde-f5bcf922cec0", UserName = "csullivan", Email = "calebs@gmail.com", PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])},
            new IdentityUser {Id = "075aa239-f0fa-46d7-8cb5-223d4064e582", UserName = "joshb", Email = "joshb@gmail.com", PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])},

        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile {Id = 1, IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", FirstName = "Admina", LastName = "Strator", Address = "101 Main Street"},
            new UserProfile {Id = 2, IdentityUserId = "5b795ef4-89bd-4de6-b6e1-6bb3dc469242", FirstName = "JD", LastName = "Fitzmartin", Address = "132 Main Street"},
            new UserProfile {Id = 3, IdentityUserId = "e53af84d-c3d0-4db8-9a6a-680985b82553", FirstName = "Greg", LastName = "Korte", Address = "523 Ocean Ave"},
            new UserProfile {Id = 4, IdentityUserId = "6245ffde-88da-4745-bd81-32943de1fa00", FirstName = "Josh", LastName = "Barton", Address = "636 Palm Street"},
            new UserProfile {Id = 5, IdentityUserId = "8fe414ed-22f8-4dd5-8cde-f5bcf922cec0", FirstName = "Caleb", LastName = "Sullivan", Address = "5345 Equador Way"},
            new UserProfile {Id = 6, IdentityUserId = "075aa239-f0fa-46d7-8cb5-223d4064e582", FirstName = "Josh", LastName = "Baugh", Address = "643 Palm Street"}
        });

        modelBuilder.Entity<Order>().HasData(new Order[]
        {
            new Order {Id = 1, EmployeeId = 2, TableNumber = 3, Tipped = 6.80M, OrderDate = new DateTime(2023, 09, 16, 17, 30, 50)},
            new Order {Id = 2, EmployeeId = 2, DriverId = 4, Tipped = 11M, OrderDate = new DateTime(2023, 09, 16, 18, 25, 22)},
            new Order {Id = 3, EmployeeId = 3, TableNumber = 6, OrderDate = new DateTime(2023, 09, 17, 12, 04, 35)},
            new Order {Id = 4, EmployeeId = 6, DriverId = 5, Tipped = 8.75M, OrderDate = new DateTime(2023, 09, 18, 12, 04, 11)},
            new Order {Id = 5, EmployeeId = 5, DriverId = 4, Tipped = 4.95M, OrderDate = new DateTime(2023, 09, 18, 13, 48, 37)},
            new Order {Id = 6, EmployeeId = 4, TableNumber = 1, Tipped = 12M, OrderDate = new DateTime(2023, 09, 18, 15, 22, 58)},
            new Order {Id = 7, EmployeeId = 5, TableNumber = 2, OrderDate = new DateTime(2023, 09, 20, 11, 07, 47)},
            new Order {Id = 8, EmployeeId = 3, DriverId = 6, Tipped = 8.55M, OrderDate = new DateTime(2023, 09, 22, 12, 34, 51)},
            new Order {Id = 9, EmployeeId = 2, DriverId = 5, Tipped = 6.39M, OrderDate = new DateTime(2023, 09, 22, 14, 41, 08)}
        });

        modelBuilder.Entity<Pizza>().HasData(new Pizza[]
        {
            new Pizza {Id = 1, SizeId = 2, CheeseId = 1, SauceId = 1, OrderId = 1},
            new Pizza {Id = 2, SizeId = 1, CheeseId = 2, SauceId = 5, OrderId = 2},
            new Pizza {Id = 3, SizeId = 2, CheeseId = 5, SauceId = 3, OrderId = 2},
            new Pizza {Id = 4, SizeId = 3, CheeseId = 4, SauceId = 4, OrderId = 3},
            new Pizza {Id = 5, SizeId = 3, CheeseId = 6, SauceId = 2, OrderId = 4},
            new Pizza {Id = 6, SizeId = 1, CheeseId = 2, SauceId = 4, OrderId = 4},
            new Pizza {Id = 7, SizeId = 1, CheeseId = 1, SauceId = 3, OrderId = 5},
            new Pizza {Id = 8, SizeId = 1, CheeseId = 3, SauceId = 1, OrderId = 6},
            new Pizza {Id = 9, SizeId = 2, CheeseId = 4, SauceId = 5, OrderId = 6},
            new Pizza {Id = 10, SizeId = 3, CheeseId = 3, SauceId = 1, OrderId = 6},
            new Pizza {Id = 11, SizeId = 1, CheeseId = 5, SauceId = 1, OrderId = 7},
            new Pizza {Id = 12, SizeId = 2, CheeseId = 1, SauceId = 2, OrderId = 8},
            new Pizza {Id = 13, SizeId = 1, CheeseId = 6, SauceId = 3, OrderId = 8},
            new Pizza {Id = 14, SizeId = 2, CheeseId = 1, SauceId = 3, OrderId = 9},
            new Pizza {Id = 15, SizeId = 3, CheeseId = 2, SauceId = 1, OrderId = 9}
        });

        modelBuilder.Entity<PizzaTopping>().HasData(new PizzaTopping[]
        {
            new PizzaTopping {Id = 1, PizzaId = 1, ToppingId = 1, Quantity = 8},
            new PizzaTopping {Id = 2, PizzaId = 1, ToppingId = 8, Quantity = 8},
            new PizzaTopping {Id = 3, PizzaId = 1, ToppingId = 9, Quantity = 8},
            new PizzaTopping {Id = 4, PizzaId = 2, ToppingId = 1, Quantity = 10},
            new PizzaTopping {Id = 5, PizzaId = 3, ToppingId = 1, Quantity = 11},
            new PizzaTopping {Id = 6, PizzaId = 3, ToppingId = 2, Quantity = 7},
            new PizzaTopping {Id = 7, PizzaId = 4, ToppingId = 1, Quantity = 9},
            new PizzaTopping {Id = 8, PizzaId = 5, ToppingId = 3, Quantity = 12},
            new PizzaTopping {Id = 9, PizzaId = 5, ToppingId = 4, Quantity = 15},
            new PizzaTopping {Id = 10, PizzaId = 5, ToppingId = 5, Quantity = 7},
            new PizzaTopping {Id = 11, PizzaId = 6, ToppingId = 1, Quantity = 7},
            new PizzaTopping {Id = 12, PizzaId = 6, ToppingId = 7, Quantity = 4},
            new PizzaTopping {Id = 13, PizzaId = 7, ToppingId = 1, Quantity = 10},
            new PizzaTopping {Id = 14, PizzaId = 8, ToppingId = 11, Quantity = 11},
            new PizzaTopping {Id = 15, PizzaId = 9, ToppingId = 8, Quantity = 12},
            new PizzaTopping {Id = 16, PizzaId = 9, ToppingId = 10, Quantity = 10},
            new PizzaTopping {Id = 17, PizzaId = 10, ToppingId = 4, Quantity = 5},
            new PizzaTopping {Id = 18, PizzaId = 11, ToppingId = 1, Quantity = 6},
            new PizzaTopping {Id = 19, PizzaId = 11, ToppingId = 3, Quantity = 8},
            new PizzaTopping {Id = 20, PizzaId = 11, ToppingId = 6, Quantity = 7},
            new PizzaTopping {Id = 21, PizzaId = 12, ToppingId = 1, Quantity = 8},
            new PizzaTopping {Id = 22, PizzaId = 12, ToppingId = 5, Quantity = 9},
            new PizzaTopping {Id = 23, PizzaId = 13, ToppingId = 1, Quantity = 10},
            new PizzaTopping {Id = 24, PizzaId = 14, ToppingId = 2, Quantity = 10},
            new PizzaTopping {Id = 25, PizzaId = 15, ToppingId = 2, Quantity = 7},
            new PizzaTopping {Id = 26, PizzaId = 15, ToppingId = 3, Quantity = 8}
        });

        modelBuilder.Entity<Size>().HasData(new Size[]
        {
            new Size {Id = 1, Name = "Small", Length = "10\"", Cost = 10.00M},
            new Size {Id = 2, Name = "Medium", Length = "14\"", Cost = 12.00M},
            new Size {Id = 3, Name = "Large", Length = "18\"", Cost = 15.00M}
        });

        modelBuilder.Entity<Cheese>().HasData(new Cheese[]
        {
            new Cheese {Id = 1, Type = "Mozzarella"},
            new Cheese {Id = 2, Type = "Buffalo Mozzarella"},
            new Cheese {Id = 3, Type = "Four Cheese"},
            new Cheese {Id = 4, Type = "Vegan"},
            new Cheese {Id = 5, Type = "Parmesan"},
            new Cheese {Id = 6, Type = "None (Cheeseless)"}
        });

        modelBuilder.Entity<Sauce>().HasData(new Sauce[]
        {
            new Sauce {Id = 1, Type = "Marinara"},
            new Sauce {Id = 2, Type = "Arrabbiata"},
            new Sauce {Id = 3, Type = "Garlic White"},
            new Sauce {Id = 4, Type = "Pesto"},
            new Sauce {Id = 5, Type = "None (Sauceless)"}
        });

        modelBuilder.Entity<Topping>().HasData(new Topping[]
        {
            new Topping {Id = 1, Name = "Pepperoni"},
            new Topping {Id = 2, Name = "Sausage"},
            new Topping {Id = 3, Name = "Mushroom"},
            new Topping {Id = 4, Name = "Onion"},
            new Topping {Id = 5, Name = "Green Pepper"},
            new Topping {Id = 6, Name = "Black Olive"},
            new Topping {Id = 7, Name = "Basil"},
            new Topping {Id = 8, Name = "Bacon"},
            new Topping {Id = 9, Name = "Spinach"},
            new Topping {Id = 10, Name = "Pineapple"},
            new Topping {Id = 11, Name = "Extra Cheese"}
        });
    }
}