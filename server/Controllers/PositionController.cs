using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.DTOs;
using server.Services.Interfaces;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionController : ControllerBase
{
    private readonly IPositionService _positionService;

    public PositionController(IPositionService positionService)
    {
        _positionService = positionService;
    }

    [HttpPost("create")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> CreatePosition(CreatePositionRequestDto request)
    {
        await _positionService.CreatePositionAsync(request);
        return Ok(new{message = "Position successfully created"});
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllPosition()
    {
        var response = await _positionService.GetAllPositionAsync();
        return Ok(response);
    }

    [HttpGet("byId")]
    public async Task<IActionResult> GetPositionById(GetPositionByIdRequestDto request)
    {
        var response = await _positionService.GetPositionByIdAsync(request);
        return Ok(response);
    }

    [HttpPut("update")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> UpdatePosition(UpdatePositionRequestDto request)
    {
        await _positionService.UpdatePositionAsync(request);
        return Ok(new{message = "Position updated successfully"});
    }

    [HttpDelete("delete")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> DeletePosition(DeletePositionRequestDto request)
    {
        await _positionService.DeletePositionAsync(request);
        return Ok(new{message = "Position deleted successfully"});
    }
}