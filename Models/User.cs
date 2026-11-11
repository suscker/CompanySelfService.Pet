
using Microsoft.AspNetCore.Identity;

namespace CompanySelfService.Pet.Models;

public class User
{
    public Guid Id {get; set;}

    public string FirstName {get; set;} = string.Empty;

    public string LastName {get; set;} = string.Empty;

    public string Email {get; set;} = string.Empty;

    public DateTimeOffset CreatedAt {get; set;}

    public string PasswordHash {get; set;} = string.Empty;

    public string Role {get; set;} = string.Empty;

    public ICollection<AccessPass> Passes { get; set; } = new List<AccessPass>();
}