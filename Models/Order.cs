using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShepherdsPies.Models;

public class Order
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public UserProfile Employee { get; set; }
    public int? TableNumber { get; set; }
    public int? DriverId { get; set; }
    [ForeignKey("DriverId")]
    public UserProfile Driver { get; set; }
    private static readonly decimal _deliveryCost = 5.00M;
    public decimal? Tipped { get; set; }
    [Required]
    public DateTime OrderDate { get; set; }
    public List<Pizza> Pizzas { get; set; }
    public decimal TotalCost
    {
        get
        {
            decimal total = 0.0M;

            foreach (Pizza p in Pizzas)
            {
                total += p.Cost;
            }

            if (DriverId.HasValue)
            {
                total += _deliveryCost;
            }

            if (Tipped.HasValue)
            {
                total += (decimal)Tipped;
            }

            return total;
        }
    }
}