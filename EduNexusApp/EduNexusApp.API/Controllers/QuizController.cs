using Microsoft.AspNetCore.Mvc;
using EduNexusApp.API.Data;
using EduNexusApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EduAwarenessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly EduNexusDbContext _context;

        public QuizController(EduNexusDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz([FromBody] Quiz quiz)
        {
            quiz.Id = Guid.NewGuid();
            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();
            return Ok(quiz);
        }

        [HttpGet("slide/{slideId}")]
        public async Task<IActionResult> GetQuizzesBySlide(Guid slideId)
        {
            var quizzes = await _context.Quizzes
                .Where(q => q.SlideId == slideId)
                .ToListAsync();

            return Ok(quizzes);
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitAnswer([FromBody] QuizAnswer answer)
        {
            var quiz = await _context.Quizzes.FindAsync(answer.QuizId);
            if (quiz == null)
                return NotFound("Quiz not found");

            bool isCorrect = answer.SelectedIndex == quiz.CorrectOptionIndex;
            return Ok(new { isCorrect });
        }
    }

    public class QuizAnswer
    {
        public Guid QuizId { get; set; }
        public int SelectedIndex { get; set; }
    }
}