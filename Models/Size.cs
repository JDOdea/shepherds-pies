using System.ComponentModel.DataAnnotations;

namespace ShepherdsPies.Models;

public class Size
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Length { get; set; }
    public decimal Cost { get; set; }
}