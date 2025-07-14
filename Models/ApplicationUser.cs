using System;
using Microsoft.AspNetCore.Identity;

namespace BugTrackerAPI.Models;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
}
