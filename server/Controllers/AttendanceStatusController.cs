using Microsoft.AspNetCore.Mvc;
using server.DTOs;
using server.Services.Interfaces;

[ApiController]
[Route("api/controller")]
public class AttendanceStatusController : ControllerBase
{
    private readonly IAttendanceStatusService _asService;

    public AttendanceStatusController(IAttendanceStatusService asService)
    {
        _asService = asService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAttendanceStatus(CreateAttendanceStatusRequestDto request)
    {
        await _asService.CreateAttendanceStatusAsync(request);
        return Ok(new{message = "Attendance status created successfully"});
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAttendanceStatus()
    {
        var response = await _asService.GetAllAttendanceStatusAsync();
        return Ok(response);
    }

    [HttpGet("byId")]
    public async Task<IActionResult> GetAttendanceStatusById(GetAttendanceStatusByIdRequestDto request)
    {
        var response = await _asService.GetAttendanceStatusByIdAsync(request);
        return Ok(response);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAttendanceStatus(UpdateAttendanceStatusRequestDto request)
    {
        await _asService.UpdateAttendanceStatusAsync(request);
        return Ok(new{message = "Attendance status updated successfully"});
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAttendanceStatus(DeleteAttendanceStatusRequestDto request)
    {
        await _asService.DeleteAttendanceStatusAsync(request);
        return Ok(new{message = "Attendance status deleted successfully"});
    }
}