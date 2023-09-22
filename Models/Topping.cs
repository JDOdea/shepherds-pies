using System.ComponentModel.DataAnnotations;

namespace ShepherdsPies.Models;

public class Topping
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public decimal Price { get; } = 0.50M;
}