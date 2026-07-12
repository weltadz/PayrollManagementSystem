namespace server.DTOs;

public class UpdateRoleRequestDto
{
    public Guid RoleId { get; set;}

    public string Name { get; set;} = string.Empty;
}