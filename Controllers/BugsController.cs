using System.Security.Claims;
using BugTrackerAPI.Models.DTOs;
using BugTrackerAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BugsController : ControllerBase
    {
        private readonly IBugService _bugService;

        public BugsController(IBugService bugService)
        {
            _bugService = bugService;
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBugRequest request)
        {
            var userId = GetUserId();
            Console.WriteLine($"User ID from token: {userId}");

            var bug = await _bugService.CreateAsync(GetUserId(), request);
            return Ok(bug);
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBugs()
        {
            var bugs = await _bugService.GetAllForUserAsync(GetUserId());
            return Ok(bugs);
        }

        [HttpPost("{id}/assign")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Assign(int id, AssignBugRequest request)
        {
            var result = await _bugService.AssignAsync(id, request.AssigneeId);
            if (!result) return NotFound();
            return Ok("Bug assigned");
        }
    }
}
