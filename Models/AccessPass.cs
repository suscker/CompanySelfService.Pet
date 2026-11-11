
namespace CompanySelfService.Pet.Models;

public class AccessPass
{
    public Guid Id {get; set;}

    public Guid UserId {get; set;}

    public Guid BuildingObjectId {get; set;} 

    public bool IsActive {get; set;}

    public DateTimeOffset IssuedAt {get; set;}

    public DateTimeOffset? RevokedAt {get; set;}

    public Guid IssuedByUserId {get; set;}

    public User IssuedBy { get; set; } = null!;

    public User User {get; set;} = null!;

    public BuildingObject BuildingObject {get; set;} = null!;
}