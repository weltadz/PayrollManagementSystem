using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs;
using server.Model;
using server.Services.Interfaces;
using server.Services.Interfaces.Security;

namespace server.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(ApplicationDbContext dbContext, IPasswordHasher passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }

    public async Task CreateUserAsync(CreateUserRequestDto request)
    {
        var existingUser = await _dbContext.Users
        .FirstOrDefaultAsync(u => u.Username == request.Username);

        if (existingUser != null)
        {
            throw new InvalidOperationException("Username unavailable");
        }

        existingUser = new User
        {
            UserId = Guid.NewGuid(),
            Username = request.Username,
            Email = request.Email,
            RoleId = request.RoleId
        };

        existingUser.PasswordHash = _passwordHasher.HashPassword(existingUser, request.PasswordHash);

        _dbContext.Users.Add(existingUser);
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<GetUserResponseDto>> GetAllUserAsync()
    {
        var user = await _dbContext.Users
        .Select(u => new GetUserResponseDto
        {
            UserId = u.UserId,
            Username = u.Username,
            Email = u.Email,
            RoleName = u.Role.Name
        })
        .ToListAsync();

        return user;
    }

    public async Task<GetUserResponseDto> GetUserByIdAsync(GetUserByIdRequestDto request)
    {
        var user = await _dbContext.Users
        .Include(u => u.Role)
        .FirstOrDefaultAsync(u => u.UserId == request.UserId);

        if(user == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        return new GetUserResponseDto
        {
            UserId = user.UserId,
            Username = user.Username,
            Email = user.Email,
            RoleName = user.Role.Name
        };
    }

    public async Task UpdateUserAsync(UpdateUserRequestDto request)
    {
        var user = await _dbContext.Users
        .FirstOrDefaultAsync(u => u.UserId == request.UserId);

        if(user == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        user.Username = request.Username;
        user.Email = request.Email;
        user.RoleId = request.RoleId;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(DeleteUserRequestDto request)
    {
        var user = await _dbContext.Users
        .FirstOrDefaultAsync(u => u.UserId == request.UserId);

        if(user == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        _dbContext.Users.Remove(user);

        await _dbContext.SaveChangesAsync();
    }
}