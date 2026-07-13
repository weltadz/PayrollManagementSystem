using server.DTOs;

namespace server.Services.Interfaces;

public interface IUserService
{
     Task CreateUserAsync(CreateUserRequestDto request);

     Task<List<GetUserResponseDto>> GetAllUserAsync();

     Task<GetUserResponseDto> GetUserByIdAsync(GetUserByIdRequestDto request);

     Task UpdateUserAsync(UpdateUserRequestDto request);

     Task DeleteUserAsync(DeleteUserRequestDto request);
}