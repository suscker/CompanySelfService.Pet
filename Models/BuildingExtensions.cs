
using CompanySelfService.Pet.DTOs;

namespace CompanySelfService.Pet.Models;

public static class BuildingExtensions
{
    public static BuildingResponseDto ToResponseDto(this BuildingObject building)
    {
        BuildingResponseDto response = new()
        {
            Id = building.Id,
            Name = building.Name,
            Address = building.Address,
            CreatedAt = building.CreatedAt

        };
        return response;

    }
}