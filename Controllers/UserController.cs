
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CompanySelfService.Pet.DTOs;
using CompanySelfService.Pet.Models;
using System.Data;
using MediatR;
using CompanySelfService.Pet.Users.Commands;
using CompanySelfService.Pet.Users.Queries;
namespace CompanySelfService.Pet.Controllers;

[Authorize]
[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateUserDto([FromBody] CreateUserDto dto)
    {
        var command = new CreateUserCommand(dto.Name, dto.LastName, dto.Email, dto.Password, dto.Role);

        var user = await _mediator.Send(command);


        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var command = new GetUsersQuery();

        var users = await _mediator.Send(command);

        return Ok(users);

    }


    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        LoginCommand command = new(loginDto.Email, loginDto.Password);
        var token = await _mediator.Send(command);

        if(token is null)
        {
            return Unauthorized("Неверный Email или пароль");
        }
        return Ok(new {Token = token});
    }
}