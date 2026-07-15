using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs;
using server.Model;
using server.Services.Interfaces;

public class DepartmentService : IDepartmentService
{
    private readonly ApplicationDbContext _dbContext;

    public DepartmentService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateDepartmentAsync(CreateDepartmentRequestDto request)
    {
        var exisitingDepartment = await _dbContext.Departments
        .FirstOrDefaultAsync(d => d.Name == request.Name);

        if(exisitingDepartment != null)
        {
            throw new InvalidOperationException("Department already exist");
        }

        exisitingDepartment = new Department
        {
            DepartmentId = Guid.NewGuid(),
            Name = request.Name
        };

        _dbContext.Departments.Add(exisitingDepartment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<GetDepartmentResponseDto>> GetAllDepartmentAsync()
    {
        var department = await _dbContext.Departments
        .Select(d => new GetDepartmentResponseDto
        {
            DepartmentId = d.DepartmentId,
            Name = d.Name
        })
        .ToListAsync();

        return department;
    }

    public async Task<GetDepartmentResponseDto> GetDepartmentByIdAsync(GetDepartmentByIdRequestDto request)
    {
        var existingDepartment = await _dbContext.Departments
        .FirstOrDefaultAsync(d => d.DepartmentId == request.DepartmentId);

        if(existingDepartment == null)
        {
            throw new KeyNotFoundException("Department not found");
        }

        return new GetDepartmentResponseDto
        {
            DepartmentId = existingDepartment.DepartmentId,
            Name = existingDepartment.Name
        };
    }

    public async Task UpdateDepartmentAsync(UpdateDepartmentRequestDto request)
    {
        var existingDepartment = await _dbContext.Departments
        .FirstOrDefaultAsync(d => d.DepartmentId == request.DepartmentId);

        if(existingDepartment == null)
        {
            throw new KeyNotFoundException("Department not found");
        }

        existingDepartment.Name = request.Name;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteDepartmentAsync(DeleteDepartmentRequestDto request)
    {
        var existingDepartment = await _dbContext.Departments
        .FirstOrDefaultAsync(d => d.DepartmentId == request.DepartmentId);

        if(existingDepartment == null)
        {
            throw new KeyNotFoundException("Department not found");
        }

        _dbContext.Departments.Remove(existingDepartment);
        await _dbContext.SaveChangesAsync();
    }
}