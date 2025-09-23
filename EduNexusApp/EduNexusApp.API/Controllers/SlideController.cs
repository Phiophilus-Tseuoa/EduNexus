using Microsoft.AspNetCore.Mvc;
using EduNexusApp.API.Data;
using EduNexusApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EduAwarenessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SlideController : ControllerBase
    {
        private readonly EduNexusDbContext _context;

        public SlideController(EduNexusDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> UploadSlide([FromBody] Slide slide)
        {
            slide.Id = Guid.NewGuid();
            _context.Slides.Add(slide);
            await _context.SaveChangesAsync();
            return Ok(slide);
        }

        [HttpGet("subject/{subjectId}")]
        public async Task<IActionResult> GetSlidesBySubject(Guid subjectId)
        {
            var slides = await _context.Slides
                .Where(s => s.SubjectId == subjectId)
                .ToListAsync();

            return Ok(slides);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSlideById(Guid id)
        {
            var slide = await _context.Slides.FindAsync(id);
            return slide == null ? NotFound() : Ok(slide);
        }
    }
}