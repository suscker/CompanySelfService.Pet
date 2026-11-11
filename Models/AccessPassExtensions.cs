
using CompanySelfService.Pet.DTOs;

namespace CompanySelfService.Pet.Models;

public static class AccessPassExtensions
{
    public static AccessPassResponseDto ToResponseDto(this AccessPass accessPass)
    {
        AccessPassResponseDto response = new()
        {
            Id = accessPass.Id,
            UserId = accessPass.UserId,
            BuildingObjectId = accessPass.BuildingObjectId,
            IsActive = accessPass.IsActive,
            IssuedAt = accessPass.IssuedAt,
            RevokedAt = accessPass.RevokedAt,
            IssuedByUserId = accessPass.IssuedByUserId

        };
        return response;

    }
}