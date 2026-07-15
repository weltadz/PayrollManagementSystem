using server.Services.Interfaces;
using server.DTOs;
using server.Data;
using Microsoft.EntityFrameworkCore;
using server.Model;

namespace server.Services;

public class PositionService : IPositionService
{
    private readonly ApplicationDbContext _dbContext;

    public PositionService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreatePositionAsync(CreatePositionRequestDto request)
    {
        var existingPosition = await _dbContext.Positions
        .FirstOrDefaultAsync(p => p.Name == request.Name);

        if(existingPosition != null)
        {
            throw new InvalidOperationException("Position already exist");
        }

        existingPosition = new Position
        {
            PositionId = Guid.NewGuid(),
            Name = request.Name,
            IsActive = true
        };

        _dbContext.Positions.Add(existingPosition);
        await _dbContext.SaveChangesAsync();    
    }

    public async Task<List<GetPositionResponseDto>> GetAllPositionAsync()
    {
        var positions = await _dbContext.Positions
        .Select(p => new GetPositionResponseDto
        {
            PositionId = p.PositionId,
            Name = p.Name,
            IsActive = p.IsActive
        })
        .ToListAsync();

        return positions;
    }

    public async Task<GetPositionResponseDto> GetPositionByIdAsync(GetPositionByIdRequestDto request)
    {
        var existingPosition = await _dbContext.Positions
        .Select(p => new GetPositionResponseDto
        {
            PositionId = p.PositionId,
            Name = p.Name,
            IsActive = p.IsActive
        })
        .FirstOrDefaultAsync(p => p.PositionId == request.PositionId);

        if(existingPosition == null)
        {
            throw new KeyNotFoundException("Position not found");
        }

        return existingPosition;
    }

    public async Task UpdatePositionAsync(UpdatePositionRequestDto request)
    {
        var existingPosition = await _dbContext.Positions
        .FirstOrDefaultAsync(p => p.PositionId == request.PositionId);

        if(existingPosition == null)
        {
            throw new KeyNotFoundException("Position not found");
        }

        existingPosition.Name = request.Name;
        existingPosition.IsActive = request.IsActive;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeletePositionAsync(DeletePositionRequestDto request)
    {
        var existingPosition = await _dbContext.Positions
        .FirstOrDefaultAsync(p => p.PositionId == request.PositionId);

        if(existingPosition == null)
        {
            throw new KeyNotFoundException("Position not found");
        }

        _dbContext.Positions.Remove(existingPosition);
        await _dbContext.SaveChangesAsync();
    }
}