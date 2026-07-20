using server.DTOs;

namespace server.Services.Interfaces;

public interface IAttendanceStatusService
{
    Task CreateAttendanceStatusAsync(CreateAttendanceStatusRequestDto request);

    Task<List<GetAttendanceStatusResponseDto>> GetAllAttendanceStatusAsync();

    Task<GetAttendanceStatusResponseDto> GetAttendanceStatusByIdAsync(GetAttendanceStatusByIdRequestDto request);

    Task UpdateAttendanceStatusAsync(UpdateAttendanceStatusRequestDto request);

    Task DeleteAttendanceStatusAsync(DeleteAttendanceStatusRequestDto request);

}