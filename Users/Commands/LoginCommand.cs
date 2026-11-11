
using MediatR;

namespace CompanySelfService.Pet.Users.Commands;

public record LoginCommand(string Email, string password) : IRequest<string>;