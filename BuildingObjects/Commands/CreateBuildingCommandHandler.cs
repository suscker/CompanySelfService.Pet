
using CompanySelfService.Pet.DTOs;
using CompanySelfService.Pet.Models;
using MediatR;


namespace CompanySelfService.Pet.BuildingObjects.Commands;

internal class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand, BuildingResponseDto>
{
    private readonly AppDbContext _context;
    public CreateBuildingCommandHandler(AppDbContext db)
    {
        _context = db;
    }
    public async Task<BuildingResponseDto> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
    {
        BuildingObject building = new()
        {
            Id = Guid.CreateVersion7(),
            Name = request.Name,
            Address = request.Address,
            CreatedAt = DateTimeOffset.UtcNow,
            Passes = new List<AccessPass>()
        };
        
        await _context.BuildingObjects.AddAsync(building);
        await _context.SaveChangesAsync();
        return building.ToResponseDto();
    }
}