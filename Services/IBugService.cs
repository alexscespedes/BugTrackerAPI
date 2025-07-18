using System;
using BugTrackerAPI.Models;
using BugTrackerAPI.Models.DTOs;

namespace BugTrackerAPI.Services;

public interface IBugService
{
    Task<Bug> CreateAsync(string reportedId, CreateBugRequest request);
    Task<IEnumerable<Bug>> GetAllForUserAsync(string userId);
    Task<Bug?> GetByIdAsync(int id);
    Task<bool> AssignAsync(int id, string assigneeId);
}
