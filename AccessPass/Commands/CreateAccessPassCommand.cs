

using CompanySelfService.Pet.DTOs;
using MediatR;

namespace CompanySelfService.Pet.AccessPasses.Commands;

public record CreateAccessPassCommand(Guid UserId, Guid BuildObjectId, Guid AdminId) : IRequest<AccessPassResponseDto>;
