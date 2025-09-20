using Microsoft.AspNetCore.Mvc;
using EduNexusApp.Shared.Models;

namespace EduNexusApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // Temporary in-memory store
        private static readonly List<User> Users = new();

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var existingUser = Users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
                return Ok(existingUser);

            user.Id = Guid.NewGuid();
            Users.Add(user);
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            return user == null ? NotFound() : Ok(user);
        }
    }
}