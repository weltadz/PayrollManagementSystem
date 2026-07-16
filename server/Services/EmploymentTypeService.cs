using server.Services.Interfaces;
using server.Data;
using server.DTOs;
using Microsoft.EntityFrameworkCore;
using server.Model;

public class EmploymentTypeService : IEmploymentTypeService
{
    private readonly ApplicationDbContext _dbContext;

    public EmploymentTypeService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateEmploymentTypeAsync(CreateEmploymentTypeRequestDto request)
    {
        var existingEmploymentType = await _dbContext.EmploymentTypes
        .FirstOrDefaultAsync(et => et.Name == request.Name);

        if(existingEmploymentType != null)
        {
            throw new InvalidOperationException("Employment type already exist");
        }

        existingEmploymentType = new EmploymentType
        {
            EmploymentTypeId = Guid.NewGuid(),
            Name = request.Name,
            IsActive = true
        };

        _dbContext.EmploymentTypes.Add(existingEmploymentType);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<GetEmploymentTypeResponseDto>> GetAllEmploymentTypeAsync()
    {
        var employmentTypes = await _dbContext.EmploymentTypes
        .Select(et => new GetEmploymentTypeResponseDto
        {
            EmploymentTypeId = et.EmploymentTypeId,
            Name = et.Name,
            IsActive = et.IsActive
        })
        .ToListAsync();

        return employmentTypes;
    }

    public async Task<GetEmploymentTypeResponseDto> GetEmploymentTypeByIdAsync(GetEmploymentTypeByIdRequestDto request)
    {
        var existingEmploymentType = await _dbContext.EmploymentTypes
        .Select(et => new GetEmploymentTypeResponseDto
        {
            EmploymentTypeId = et.EmploymentTypeId,
            Name = et.Name,
            IsActive = et.IsActive
        })
        .FirstOrDefaultAsync(et => et.EmploymentTypeId == request.EmploymentTypeId);

        if(existingEmploymentType == null)
        {
            throw new KeyNotFoundException("Employment type not found");
        }

        return existingEmploymentType;
    }

    public async Task UpdateEmploymentTypeAsync(UpdateEmploymentTypeRequestDto request)
    {
        var existingEmploymentType = await _dbContext.EmploymentTypes
        .FirstOrDefaultAsync(et => et.EmploymentTypeId == request.EmploymentTypeId);

        if(existingEmploymentType == null)
        {
            throw new KeyNotFoundException("Employment type not found");
        }

        existingEmploymentType.Name = request.Name;
        existingEmploymentType.IsActive = request.IsActive;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteEmploymentTypeAsync(DeleteEmploymentTypeRequestDto request)
    {
        var existingEmploymentType = await _dbContext.EmploymentTypes
        .FirstOrDefaultAsync(et => et.EmploymentTypeId == request.EmploymentTypeId);

        if(existingEmploymentType == null)
        {
            throw new KeyNotFoundException("Employment type not found");
        }

        _dbContext.EmploymentTypes.Remove(existingEmploymentType);
        await _dbContext.SaveChangesAsync();
    }
}