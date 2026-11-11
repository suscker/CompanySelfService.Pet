
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CompanySelfService.Pet.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CompanySelfService.Pet.Users.Commands;

internal class LoginCommandHandler : IRequestHandler<LoginCommand, String>
{

    private readonly AppDbContext _context;
    private readonly JwtSettings _jwtSettings;
    
    public LoginCommandHandler(AppDbContext db, IOptions<JwtSettings> jwtSettings)
    {
        _context = db;
        _jwtSettings = jwtSettings.Value;
    }
    private string HashPassword(string password)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(bytes);
    }
    public async Task<string> Handle(LoginCommand request, CancellationToken ct)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email, ct);
        if(user is null) return null;

        string incomingHash = HashPassword(request.password);
        if(incomingHash != user.PasswordHash) return null;

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "CompanySelfService",
            audience: "CompanySelfService.Clients",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryInMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);



    }
}