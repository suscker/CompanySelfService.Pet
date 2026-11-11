
using CompanySelfService.Pet.DTOs;
using CompanySelfService.Pet.Models;
using MediatR;

namespace CompanySelfService.Pet.Users.Commands;

public record CreateUserCommand(string Name, string LastName, string Email, string password, string Role) : IRequest<UserResponseDto>;
