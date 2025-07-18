using System;

namespace BugTrackerAPI.Models.DTOs;

public class AssignBugRequest
{
    public string AssigneeId { get; set; } = string.Empty;
}
