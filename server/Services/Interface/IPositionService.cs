using server.DTOs;

namespace server.Services.Interfaces;

public interface IPositionService
{
    Task CreatePositionAsync(CreatePositionRequestDto request);

    Task<List<GetPositionResponseDto>> GetAllPositionAsync();

    Task<GetPositionResponseDto> GetPositionByIdAsync(GetPositionByIdRequestDto request);

    Task UpdatePositionAsync(UpdatePositionRequestDto request);

    Task DeletePositionAsync(DeletePositionRequestDto request);
}