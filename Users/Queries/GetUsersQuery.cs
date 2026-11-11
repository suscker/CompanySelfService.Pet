
using CompanySelfService.Pet.DTOs;
using CompanySelfService.Pet.Models;
using MediatR;

namespace CompanySelfService.Pet.Users.Queries;

public record GetUsersQuery() : IRequest<List<UserResponseDto>>; 