
namespace CompanySelfService.Pet.DTOs;

public class AccessPassResponseDto
{
    public Guid Id {get; set;}

    public Guid UserId {get; set;}

    public Guid BuildingObjectId {get; set;} 

    public bool IsActive {get; set;}

    public DateTimeOffset IssuedAt {get; set;}

    public DateTimeOffset? RevokedAt {get; set;}

    public Guid IssuedByUserId {get; set;}

}