using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.DTOs;
using server.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class EmploymentTypeController : ControllerBase
{
    private readonly IEmploymentTypeService _employmentTypeService;

    public EmploymentTypeController(IEmploymentTypeService employmentTypeService)
    {
        _employmentTypeService = employmentTypeService;
    }

    [HttpPost("create")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> CreateEmploymentType(CreateEmploymentTypeRequestDto request)
    {
        await _employmentTypeService.CreateEmploymentTypeAsync(request);
        return Ok(new{message = "Employment type created successfully"});
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllEmploymentType()
    {
        var response = await _employmentTypeService.GetAllEmploymentTypeAsync();
        return Ok(response);
    }

    [HttpGet("byId")]
    public async Task<IActionResult> GetEmploymentTypeById(GetEmploymentTypeByIdRequestDto request)
    {
        var response = await _employmentTypeService.GetEmploymentTypeByIdAsync(request);
        return Ok(response);
    }

    [HttpPut("update")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> UpdateEmploymentType(UpdateEmploymentTypeRequestDto request)
    {
        await _employmentTypeService.UpdateEmploymentTypeAsync(request);
        return Ok(new{message = "Employment type updated successfully"});
    }

    [HttpDelete("delete")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> DeleteEmploymentType(DeleteEmploymentTypeRequestDto request)
    {
        await _employmentTypeService.DeleteEmploymentTypeAsync(request);
        return Ok(new{message = "Employment type deleted successfully"});
    }
}