using System;
using BugTrackerAPI.Data;
using BugTrackerAPI.Models;
using BugTrackerAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerAPI.Services;

public class BugService : IBugService
{
    private readonly AppDbContext _context;

    public BugService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> AssignAsync(int id, string assigneeId)
    {
        var bug = await _context.Bugs.FindAsync(id);
        if (bug == null) return false;

        bug.AssigneeId = assigneeId;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Bug> CreateAsync(string reportedId, CreateBugRequest request)
    {
        Console.WriteLine($"[BugService] reporterId: {reportedId}");

        var bug = new Bug
        {
            Title = request.Title,
            Description = request.Description,
            Priority = request.Priority,
            ReporterId = reportedId,
            CreatedAt = DateTime.UtcNow
        };

        _context.Bugs.Add(bug);
        await _context.SaveChangesAsync();
        return bug;
    }

    public async Task<IEnumerable<Bug>> GetAllForUserAsync(string userId)
    {
        return await _context.Bugs
            .Include(b => b.Reporter)
            .Include(b => b.Assigne)
            .Where(b => b.ReporterId == userId || b.AssigneeId == userId).ToListAsync();
    }

    public async Task<Bug?> GetByIdAsync(int id)
    {
        return await _context.Bugs
            .Include(b => b.Reporter)
            .Include(b => b.Assigne)
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}
