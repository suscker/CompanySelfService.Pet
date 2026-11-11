

using CompanySelfService.Pet.Models;

namespace CompanySelfService.Pet.DTOs;
public class BuildingResponseDto
{

    public Guid Id {get; set; }

    public string Name {get; set; }

    public string Address {get; set;}

    public DateTimeOffset CreatedAt {get; set;}


}