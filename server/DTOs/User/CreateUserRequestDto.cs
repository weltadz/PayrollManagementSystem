namespace server.DTOs;

public class CreateUserRequestDto
{
    public string Username { get; set;} = string.Empty;

    public string Email { get; set;} = string.Empty;
    
    public string PasswordHash { get; set;} = string.Empty;

    public Guid RoleId { get; set;}
}