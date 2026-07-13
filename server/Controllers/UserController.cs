using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.DTOs;
using server.Services.Interfaces;

namespace server.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("create")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> CreateUser(CreateUserRequestDto request)
    {
        await _userService.CreateUserAsync(request);
        return Ok(new{message = "User created successfully"});      
    }

    [HttpGet("all")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> GetAllUser()
    {
        var response = await _userService.GetAllUserAsync();
        return Ok(response);
    }

    [HttpGet("getById")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> GetUserById(GetUserByIdRequestDto request)
    {
        var response = await _userService.GetUserByIdAsync(request);
        return Ok(response);
    }

    [HttpPut("update")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> UpdateUser(UpdateUserRequestDto request)
    {
        await _userService.UpdateUserAsync(request);
        return Ok(new{message = "User updated successfully"});
    }

    [HttpDelete("delete")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> DeleteUser(DeleteUserRequestDto request)
    {
        await _userService.DeleteUserAsync(request);
        return Ok(new{message = "User deleted successfully"});
    }
}