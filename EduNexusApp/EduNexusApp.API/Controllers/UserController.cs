using Microsoft.AspNetCore.Mvc;
using EduNexusApp.Shared.Models;
using EduNexusApp.API.Data;
using Microsoft.EntityFrameworkCore;

namespace EduNexusApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly EduNexusDbContext _context;

        public UserController(EduNexusDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == user.Email);

            if (existingUser != null)
                return Ok(existingUser);

            user.Id = Guid.NewGuid();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            return user == null ? NotFound() : Ok(user);
        }
    }
}