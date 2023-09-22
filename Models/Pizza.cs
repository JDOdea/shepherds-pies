namespace ShepherdsPies.Models;

public class Pizza
{
    public int Id { get; set; }
    public int SizeId { get; set; }
    public Size Size { get; set; }
    public int CheeseId { get; set; }
    public Cheese Cheese { get; set; }
    public int SauceId { get; set; }
    public Sauce Sauce { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public List<PizzaTopping> PizzaToppings { get; set; }
    public decimal Cost
    {
        get
        {
            decimal pizzaCost = 0.0M;

            foreach (PizzaTopping pt in PizzaToppings)
            {
                pizzaCost += pt.Topping.Price * pt.Quantity;
            }

            pizzaCost += Size.Cost;

            return pizzaCost;
        }
    }
}