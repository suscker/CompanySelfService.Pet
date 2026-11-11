
using System.Data;
using CompanySelfService.Pet.DTOs;
using CompanySelfService.Pet.Models;
using MediatR;

namespace CompanySelfService.Pet.Users.Commands;

internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserResponseDto>
{
    private readonly AppDbContext _context;
    public CreateUserCommandHandler(AppDbContext db)
    {
        _context = db;
        
    }
    private string HashPassword(string password)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(bytes);
    }
    public async Task<UserResponseDto> Handle(CreateUserCommand request, CancellationToken ct)
    {
        User user = new()
        {
            Id = Guid.NewGuid(),
            FirstName = request.Name,
            LastName = request.LastName,
            Email = request.Email,
            CreatedAt = DateTimeOffset.UtcNow,
            PasswordHash = HashPassword(request.password),
            Role = request.Role
        };
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user.ToResponseDto();

    } 
    
}