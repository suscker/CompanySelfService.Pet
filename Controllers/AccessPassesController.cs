
using CompanySelfService.Pet.AccessPasses.Commands;
using CompanySelfService.Pet.BuildingObjects.Commands;
using CompanySelfService.Pet.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanySelfService.Pet.Controllers;


[Authorize]
[ApiController]
[Route("api/AccessPasses")]
public class AccessPassesController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public AccessPassesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAccessPasses([FromBody] CreateAccessPassDto dto)
    {
        var adminIdString = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if(string.IsNullOrWhiteSpace(adminIdString)) return Unauthorized();

        var adminId = Guid.Parse(adminIdString);

        CreateAccessPassCommand command = new(dto.UserId, dto.BuildingObjectId, adminId);

        var building = await _mediator.Send(command);


        if(building is null) return BadRequest("Такой пропуск уже существует");
        
        return Ok(building);
        
    }
}


