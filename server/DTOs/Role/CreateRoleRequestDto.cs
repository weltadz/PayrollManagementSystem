using System.ComponentModel.DataAnnotations;

namespace server.DTOs;

public class CreateRoleRequestDto
{
    public string Name { get; set;} = string.Empty;
}