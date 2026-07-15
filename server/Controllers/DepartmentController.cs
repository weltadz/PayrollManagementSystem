using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.DTOs;
using server.Services.Interfaces;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpPost("create")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> CreateDepartment(CreateDepartmentRequestDto request)
    {
        await _departmentService.CreateDepartmentAsync(request);
        return Ok(new{message = "Department created successfully"});
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllDepartment()
    {
        var response = await _departmentService.GetAllDepartmentAsync();
        return Ok(response);
    }

    [HttpGet("byId")]
    public async Task<IActionResult> GetDepartmentById(GetDepartmentByIdRequestDto request)
    {
        var response = await _departmentService.GetDepartmentByIdAsync(request);
        return Ok(response);
    }

    [HttpPut("Update")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> UpdateDepartment(UpdateDepartmentRequestDto request)
    {
        await _departmentService.UpdateDepartmentAsync(request);
        return Ok(new{message = "Department updated successfully"});
    }


    [HttpDelete("delete")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> DeleteDepartment(DeleteDepartmentRequestDto request)
    {
        await _departmentService.DeleteDepartmentAsync(request);
        return Ok(new{message = "Department deleted successfully"});
    }
}