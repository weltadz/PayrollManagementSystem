using server.DTOs;

namespace server.Services.Interfaces;

public interface IDepartmentService
{
    Task CreateDepartmentAsync(CreateDepartmentRequestDto request);

    Task<List<GetDepartmentResponseDto>> GetAllDepartmentAsync();

    Task<GetDepartmentResponseDto> GetDepartmentByIdAsync(GetDepartmentByIdRequestDto request);

    Task UpdateDepartmentAsync(UpdateDepartmentRequestDto request);

    Task DeleteDepartmentAsync(DeleteDepartmentRequestDto request);
}