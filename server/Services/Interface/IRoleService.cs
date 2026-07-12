using server.DTOs;

namespace server.Services.Interfaces;

public interface IRoleService
{
    Task CreateRoleAsync(CreateRoleRequestDto request);

    Task<List<RoleResponseDto>> GetRolesAsync();

    Task UpdateRoleAsync(UpdateRoleRequestDto request);

    Task DeleteRoleAsync(DeleteRoleRequestDto request);
}