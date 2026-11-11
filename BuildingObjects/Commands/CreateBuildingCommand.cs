

using CompanySelfService.Pet.DTOs;
using MediatR;

namespace CompanySelfService.Pet.BuildingObjects.Commands;

public record CreateBuildingCommand(string Name, string Address) : IRequest<BuildingResponseDto>;