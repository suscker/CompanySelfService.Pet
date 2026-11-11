
using System.ComponentModel.DataAnnotations;

namespace CompanySelfService.Pet.DTOs;

public class CreateBuildingDto
{
    [Required, MaxLength(100)]
    public string Name {get; set;}

    [Required, MaxLength(100)]
    public string Address {get; set;}

}
