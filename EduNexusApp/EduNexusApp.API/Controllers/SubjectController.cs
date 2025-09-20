using Microsoft.AspNetCore.Mvc;
using EduNexusApp.Shared.Models;

namespace EduNexusApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private static readonly List<Subject> Subjects = new();

        [HttpPost]
        public IActionResult CreateSubject([FromBody] Subject subject)
        {
            subject.Id = Guid.NewGuid();
            Subjects.Add(subject);
            return Ok(subject);
        }

        [HttpGet]
        public IActionResult GetSubjects()
        {
            return Ok(Subjects);
        }
    }
}