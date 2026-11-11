
using CompanySelfService.Pet.DTOs;
using CompanySelfService.Pet.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanySelfService.Pet.Users.Queries;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserResponseDto>>
{
    AppDbContext _context;
    public GetUsersQueryHandler(AppDbContext db)
    {
        _context = db;
    }

    public async Task<List<UserResponseDto>> Handle(GetUsersQuery request, CancellationToken ct)
    {
        var users = await _context.Users.ToListAsync(ct);

        return users.Select(u => u.ToResponseDto()).ToList();

    }
}