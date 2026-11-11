
using System.ComponentModel.DataAnnotations;

namespace CompanySelfService.Pet.DTOs;
public class CreateUserDto
{

    [Required, MaxLength(50)]
    public string Name {get; set;}

    [Required, MaxLength(50)] 
    public string LastName {get; set;}

    [Required, EmailAddress]
    public string Email {get; set;}

    [Required]
    public string Password {get; set;}

    [Required]
    public string Role {get; set;}

}