using Microsoft.AspNetCore.Identity;
using server.Model;

namespace server.Services.Interfaces.Security;

public interface IPasswordHasher
{
    string HashPassword (User user, string password);

    PasswordVerificationResult VerifyPassword (User user, string hashedPassword, string providedPassword);
}