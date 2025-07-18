using System;

namespace BugTrackerAPI.Models.DTOs;

public class CreateBugRequest
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public BugPriority Priority { get; set; } = BugPriority.Medium;
}
