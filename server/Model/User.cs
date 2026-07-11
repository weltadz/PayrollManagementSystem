using System.ComponentModel.DataAnnotations;

namespace server.Model;

public class User
{
    public Guid UserId { get; set; }

    [Required]
    [MaxLength(60)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(60)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string PasswordHash { get; set; } = string.Empty;

    public Guid RoleId { get; set; }

    //Navigation
    public Role Role { get; set; } = null!;

    public ICollection<RefreshToken> RefreshTokens { get; set;} = new List<RefreshToken>();
}