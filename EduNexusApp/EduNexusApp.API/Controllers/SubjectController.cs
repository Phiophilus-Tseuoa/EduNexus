using Microsoft.AspNetCore.Mvc;
using EduNexusApp.API.Data;
using EduNexusApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EduNexusApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly EduNexusDbContext _context;

        public SubjectController(EduNexusDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody] Subject subject)
        {
            subject.Id = Guid.NewGuid();
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return Ok(subject);
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjects()
        {
            var subjects = await _context.Subjects.ToListAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(Guid id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            return subject == null ? NotFound() : Ok(subject);
        }
    }
}