using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackerAPI.Models;
   public enum BugStatus { Open, InProgress, Closed }
   public enum BugPriority { Low, Medium, High }
public class Bug
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    public BugStatus Status { get; set; } = BugStatus.Open;

    public BugPriority Priority { get; set; } = BugPriority.Medium;

    [Required]
    public string ReporterId { get; set; } = string.Empty;

    [ForeignKey("ReportedId")]
    public ApplicationUser? Reporter { get; set; }

    public string? AssigneeId { get; set; }

    [ForeignKey("AssigneeId")]
    public ApplicationUser? Assigne { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
