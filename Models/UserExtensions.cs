
using CompanySelfService.Pet.DTOs;

namespace CompanySelfService.Pet.Models;

public static class UserExtensions
{
    public static UserResponseDto ToResponseDto(this User user)
    {
        UserResponseDto response = new()
        {
            Id = user.Id,
            Name = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            CreatedAt = user.CreatedAt

        };
        return response;

    }
}