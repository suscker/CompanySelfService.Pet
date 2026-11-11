
using System.ComponentModel.DataAnnotations;

namespace CompanySelfService.Pet.DTOs;

public class CreateAccessPassDto
{

    
    [Required]
    public Guid UserId {get; set;}
    
    [Required]
    public Guid BuildingObjectId {get; set;}
}