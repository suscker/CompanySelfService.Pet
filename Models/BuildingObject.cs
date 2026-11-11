
namespace CompanySelfService.Pet.Models;

public class BuildingObject
{
    public Guid Id {get; set;}

    public string Name {get; set;} = string.Empty;

    public string Address {get; set;} = string.Empty;

    public DateTimeOffset CreatedAt {get; set;}

    public ICollection<AccessPass> Passes { get; set; } = new List<AccessPass>();

}