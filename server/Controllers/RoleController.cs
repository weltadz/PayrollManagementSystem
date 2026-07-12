using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.DTOs;
using server.Services.Interfaces;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpPost("create")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> CreateRole(CreateRoleRequestDto request)
    {
        await _roleService.CreateRoleAsync(request);
        return Ok(new{message = "Role successfully created"});
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetRole()
    {
        var role = await _roleService.GetRolesAsync();
        return Ok(role);
    }

    [HttpPut("update")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> UpdateRole(UpdateRoleRequestDto request)
    {
        await _roleService.UpdateRoleAsync(request);
        return Ok(new{message = "Role updated successfully"});
    }

    [HttpDelete("delete")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> DeleteRole(DeleteRoleRequestDto request)
    {
        await _roleService.DeleteRoleAsync(request);
        return Ok(new{message = "Role deleted successfully"});
    }
}