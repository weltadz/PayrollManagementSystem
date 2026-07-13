namespace server.DTOs;

public class UpdateUserRequestDto
{
    public Guid UserId { get; set;}

    public string Username { get; set;} = string.Empty;

    public string Email { get; set;} = string.Empty;

    public Guid RoleId { get; set;}
}