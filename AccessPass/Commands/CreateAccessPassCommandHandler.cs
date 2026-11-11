
using CompanySelfService.Pet.AccessPasses.Commands;
using CompanySelfService.Pet.DTOs;
using CompanySelfService.Pet.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CompanySelfService.Pet.AccessPasses.Commands;

internal class CreateAccessPassCommandHandler : IRequestHandler<CreateAccessPassCommand, AccessPassResponseDto>
{
    private readonly AppDbContext _context;
    public CreateAccessPassCommandHandler(AppDbContext db)
    {
        _context = db;
    }
    public async Task<AccessPassResponseDto> Handle(CreateAccessPassCommand request, CancellationToken ct)
    {
        var user = await _context.Users.AnyAsync(u => u.Id == request.UserId, ct);
        var buildObject = await _context.BuildingObjects.AnyAsync(b => b.Id == request.BuildObjectId, ct);

        if(user is false) return null;

        if(buildObject is false) return null;

        var pass = await _context.AccessPasses.AnyAsync(p => p.BuildingObjectId == request.BuildObjectId && p.UserId == request.UserId && p.IsActive == true); 

        if(pass) return null;

        AccessPass accessPass = new()
        {
            Id = Guid.CreateVersion7(),
            UserId = request.UserId,
            BuildingObjectId = request.BuildObjectId,
            IsActive = true,
            IssuedAt = DateTimeOffset.UtcNow,
            RevokedAt = null,
            IssuedByUserId = request.AdminId
        };

        await _context.AccessPasses.AddAsync(accessPass);
        await _context.SaveChangesAsync();
        return accessPass.ToResponseDto();
    }
}