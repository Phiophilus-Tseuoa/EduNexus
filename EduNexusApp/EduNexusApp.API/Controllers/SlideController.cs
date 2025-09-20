using Microsoft.AspNetCore.Mvc;
using EduNexusApp.Shared.Models;

namespace EduNexusApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SlideController : ControllerBase
    {
        private static readonly List<Slide> Slides = new();

        [HttpPost]
        public IActionResult UploadSlide([FromBody] Slide slide)
        {
            slide.Id = Guid.NewGuid();
            Slides.Add(slide);
            return Ok(slide);
        }

        [HttpGet("subject/{subjectId}")]
        public IActionResult GetSlidesBySubject(Guid subjectId)
        {
            var subjectSlides = Slides.Where(s => s.SubjectId == subjectId).ToList();
            return Ok(subjectSlides);
        }
    }
}