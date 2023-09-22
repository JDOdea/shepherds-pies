using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ShepherdsPies.Models;

public class UserProfile
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Address { get; set; }
    [NotMapped] // not mapped means that EF Core won't create column for this property in the db
    public string Email { get; set; }
    [NotMapped] // not mapped means that EF Core won't create column for this property in the db
    public string UserName { get; set; }
    [NotMapped]
    public List<string> Roles { get; set; }

    public string IdentityUserId { get; set; }

    public IdentityUser IdentityUser { get; set; }
    public string FullName 
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
}