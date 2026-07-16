using server.DTOs;

namespace server.Services.Interfaces;

public interface IEmploymentTypeService
{
    Task CreateEmploymentTypeAsync(CreateEmploymentTypeRequestDto request);

    Task<List<GetEmploymentTypeResponseDto>> GetAllEmploymentTypeAsync();

    Task<GetEmploymentTypeResponseDto> GetEmploymentTypeByIdAsync(GetEmploymentTypeByIdRequestDto request);

    Task UpdateEmploymentTypeAsync(UpdateEmploymentTypeRequestDto request);

    Task DeleteEmploymentTypeAsync(DeleteEmploymentTypeRequestDto request);
}