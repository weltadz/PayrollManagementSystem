using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs;
using server.Services.Interfaces;
using server.Model;
using server.Services.Interfaces.Security;


namespace server.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;

    public AuthService(ApplicationDbContext dbContext,IPasswordHasher passwordHasher, IJwtService jwtService)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
    {
        var existingUser = await _dbContext.Users
        .Include(u => u.Role)
        .FirstOrDefaultAsync(u => u.Username == request.Username);

        if(existingUser != null)
        {
            throw new InvalidOperationException("Username already exist");
        }

        var existingEmail = await _dbContext.Users
        .FirstOrDefaultAsync(u => u.Email == request.Email);

        if(existingEmail != null)
        {
            throw new InvalidOperationException("Email already exist");
        }

        existingUser = new User
        {
            UserId = Guid.NewGuid(),
            Username = request.Username,
            Email = request.Email,
            RoleId = request.RoleId
        };

        existingUser.PasswordHash = _passwordHasher.HashPassword(existingUser,request.Password);

        var refreshToken = _jwtService.GenerateRefreshToken();

        var refreshTokenEntity = new RefreshToken
        {
            RefreshTokenId = Guid.NewGuid(),
            UserId = existingUser.UserId,
            Token = refreshToken,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            IsRevoked = false
        };

        _dbContext.Users.Add(existingUser);
        _dbContext.RefreshTokens.Add(refreshTokenEntity);

        await _dbContext.SaveChangesAsync();

        var user = await _dbContext.Users
        .Include(u => u.Role)
        .FirstOrDefaultAsync(u => u.UserId == existingUser.UserId);

        if(user == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        var accessToken = _jwtService.GenerateAccessToken(user);

        return new AuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
    {
        var existingUser = await _dbContext.Users
        .Include(u => u.Role)
        .FirstOrDefaultAsync(u => u.Username == request.Username);

        if(existingUser == null)
        {
            throw new KeyNotFoundException("Invalid Credentials");
        }

        var verifyPassword = _passwordHasher.VerifyPassword(existingUser, existingUser.PasswordHash, request.Password);

        if(verifyPassword == PasswordVerificationResult.Failed)
        {
            throw new InvalidOperationException("Invalid Credentials");
        }

        var accessToken = _jwtService.GenerateAccessToken(existingUser);
        var refreshToken = _jwtService.GenerateRefreshToken();

        var refreshTokenEntity = await _dbContext.RefreshTokens
        .FirstOrDefaultAsync(r => r.UserId == existingUser.UserId);

        if(refreshTokenEntity != null)
        {
            refreshTokenEntity.Token = refreshToken;
            refreshTokenEntity.CreatedAt = DateTime.UtcNow;
            refreshTokenEntity.ExpiresAt = DateTime.UtcNow.AddDays(7);
            refreshTokenEntity.IsRevoked = false;

        }
        else
        {
            refreshTokenEntity = new RefreshToken
            {
                RefreshTokenId = Guid.NewGuid(),
                UserId = existingUser.UserId,
                Token = refreshToken,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };

            _dbContext.RefreshTokens.Add(refreshTokenEntity);
        }

        await _dbContext.SaveChangesAsync();

        return new AuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    public async Task<AuthResponseDto> RefreshAccessTokenAsync(RefreshTokenRequestDto request)
    {
        var existingRefreshToken = await _dbContext.RefreshTokens
        .FirstOrDefaultAsync(r => r.Token == request.RefreshToken);

        if(existingRefreshToken == null || existingRefreshToken.IsRevoked == true || existingRefreshToken.ExpiresAt < DateTime.UtcNow)
        {
            throw new KeyNotFoundException("Invalid refresh token");
        }

        var user = await _dbContext.Users
        .Include(u => u.Role)
        .FirstOrDefaultAsync(u => u.UserId == existingRefreshToken.UserId);

        if(user == null)
        {
            throw new KeyNotFoundException("User not found");
        }

        var accessToken = _jwtService.GenerateAccessToken(user);
        var refreshToken = _jwtService.GenerateRefreshToken();

        existingRefreshToken.Token = refreshToken;
        existingRefreshToken.CreatedAt = DateTime.UtcNow;
        existingRefreshToken.ExpiresAt = DateTime.UtcNow.AddDays(7);
        existingRefreshToken.IsRevoked = false;

        await _dbContext.SaveChangesAsync();

        return new AuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    public async Task LogoutAsync(RefreshTokenRequestDto request)
    {
        var existingRefreshToken = await _dbContext.RefreshTokens
        .FirstOrDefaultAsync(r => r.Token == request.RefreshToken);

        if(existingRefreshToken == null || existingRefreshToken.IsRevoked == true || existingRefreshToken.ExpiresAt < DateTime.UtcNow)
        {
            throw new KeyNotFoundException("Invalid refresh token");
        }

        existingRefreshToken.IsRevoked = true;

        await _dbContext.SaveChangesAsync();
    }
}