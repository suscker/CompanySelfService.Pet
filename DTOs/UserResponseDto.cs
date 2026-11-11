
using System.ComponentModel.DataAnnotations;

namespace CompanySelfService.Pet.DTOs;
public class UserResponseDto
{

    public Guid Id {get; set; }

    public string Name {get; set; }

    public string LastName {get; set;}

    public string Email {get; set;}

    public DateTimeOffset CreatedAt {get; set;}

}