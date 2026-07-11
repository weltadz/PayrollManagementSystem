using System.ComponentModel.DataAnnotations;

namespace server.Model;

public class Role
{
    public Guid RoleId { get; set;}

    [Required]
    [MaxLength(60)]
    public string Name { get; set;} = string.Empty;

    public ICollection<User> Users { get; set;} = new List<User>();
}