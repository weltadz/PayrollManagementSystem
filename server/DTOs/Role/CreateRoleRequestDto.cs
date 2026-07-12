using System.ComponentModel.DataAnnotations;

namespace server.DTOs;

public class CreateRoleRequestDto
{
    [Required]
    [MaxLength(60)]
    public string Name { get; set;} = string.Empty;
}