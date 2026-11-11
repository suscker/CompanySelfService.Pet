
using CompanySelfService.Pet.BuildingObjects.Commands;
using CompanySelfService.Pet.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanySelfService.Pet.Controllers;


[Authorize]
[ApiController]
[Route("api/Buildings")]
public class BuildingsController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public BuildingsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateBuilding([FromBody] CreateBuildingDto dto)
    {
        CreateBuildingCommand command = new(dto.Name, dto.Address);

        var building = await _mediator.Send(command);
        
        return Ok(building);
        
    }
}


