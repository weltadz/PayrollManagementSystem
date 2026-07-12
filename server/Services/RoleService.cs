using server.Services.Interfaces;
using server.Data;
using server.DTOs;
using Microsoft.EntityFrameworkCore;
using server.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace server.Services;

public class RoleService : IRoleService
{
    private readonly ApplicationDbContext _dbContext;

    public RoleService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateRoleAsync(CreateRoleRequestDto request)
    {
        var existingRole = await _dbContext.Roles
        .FirstOrDefaultAsync(r => r.Name == request.Name);

        if(existingRole != null)
        {
            throw new InvalidOperationException("Role already exist");
        }

        existingRole = new Role
        {
            RoleId = Guid.NewGuid(),
            Name = request.Name
        };

        _dbContext.Roles.Add(existingRole);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<RoleResponseDto>> GetRolesAsync()
    {
        var roles = await _dbContext.Roles
        .Select(r => new RoleResponseDto
        {
            RoleId = r.RoleId,
            Name = r.Name
        })
        .ToListAsync();

        return roles;
    }

    public async Task UpdateRoleAsync(UpdateRoleRequestDto request)
    {
        var role = await _dbContext.Roles
        .FirstOrDefaultAsync(r => r.RoleId == request.RoleId);

        if(role == null)
        {
            throw new KeyNotFoundException("Role not found");
        }

        var roleName = await _dbContext.Roles
        .FirstOrDefaultAsync(r => r.Name == request.Name);

        if(roleName != null)
        {
            throw new InvalidOperationException("Role already exist");
        }

        role.Name = request.Name;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteRoleAsync(DeleteRoleRequestDto request)
    {
        var role = await _dbContext.Roles
        .FirstOrDefaultAsync(r => r.RoleId == request.RoleId);

        if(role == null)
        {
            throw new KeyNotFoundException("Role not found");
        }

        _dbContext.Roles.Remove(role);

        await _dbContext.SaveChangesAsync();
    }
}