using server.Services.Interfaces;
using server.Data;
using server.DTOs;
using Microsoft.EntityFrameworkCore;
using server.Model;

namespace server.Services;

public class AttendanceStatusService : IAttendanceStatusService
{
    private readonly ApplicationDbContext _dbContext;

    public AttendanceStatusService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAttendanceStatusAsync(CreateAttendanceStatusRequestDto request)
    {
        var existingAttendanceStatus = await _dbContext.AttendanceStatuses
        .FirstOrDefaultAsync(att => att.Name == request.Name);

        if(existingAttendanceStatus != null)
        {
            throw new InvalidOperationException("Attendance status already exist");
        }

        existingAttendanceStatus = new AttendanceStatus
        {
            AttendanceStatusId = Guid.NewGuid(),
            Name = request.Name,
            IsActive = true
        };

        _dbContext.AttendanceStatuses.Add(existingAttendanceStatus);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<GetAttendanceStatusResponseDto>> GetAllAttendanceStatusAsync()
    {
        var attendanceStatus = await _dbContext.AttendanceStatuses
        .Select(att => new GetAttendanceStatusResponseDto
        {
            AttendanceStatusId = att.AttendanceStatusId,
            Name = att.Name,
            IsActive = att.IsActive
        })
        .ToListAsync();

        return attendanceStatus;
    }

    public async Task<GetAttendanceStatusResponseDto> GetAttendanceStatusByIdAsync(GetAttendanceStatusByIdRequestDto request)
    {
        var existingAttendanceStatus = await _dbContext.AttendanceStatuses
        .Select(att => new GetAttendanceStatusResponseDto
        {
            AttendanceStatusId = att.AttendanceStatusId,
            Name = att.Name,
            IsActive = att.IsActive
        })
        .FirstOrDefaultAsync(att => att.AttendanceStatusId == request.AttendanceStatusId);

        if(existingAttendanceStatus == null)
        {
            throw new KeyNotFoundException("Attendance status not found");
        }

        return existingAttendanceStatus;
    }

    public async Task UpdateAttendanceStatusAsync(UpdateAttendanceStatusRequestDto request)
    {
        var existingAttendanceStatus = await _dbContext.AttendanceStatuses
        .FirstOrDefaultAsync(att => att.AttendanceStatusId == request.AttendanceStatusId);

        if(existingAttendanceStatus == null)
        {
            throw new KeyNotFoundException("Attendance status not found");
        }

        existingAttendanceStatus.Name = request.Name;
        existingAttendanceStatus.IsActive = request.IsActive;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAttendanceStatusAsync(DeleteAttendanceStatusRequestDto request)
    {
        var existingAttendanceStatus = await _dbContext.AttendanceStatuses
        .FirstOrDefaultAsync(att => att.AttendanceStatusId == request.AttendanceStatusId);

        if(existingAttendanceStatus == null)
        {
            throw new KeyNotFoundException("Attendance status not found");
        }

        _dbContext.AttendanceStatuses.Remove(existingAttendanceStatus);
        await _dbContext.SaveChangesAsync();
    }
}