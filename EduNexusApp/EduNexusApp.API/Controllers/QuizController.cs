using Microsoft.AspNetCore.Mvc;
using EduNexusApp.Shared.Models;

namespace EduNexusApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private static readonly List<Quiz> Quizzes = new();

        [HttpPost]
        public IActionResult CreateQuiz([FromBody] Quiz quiz)
        {
            quiz.Id = Guid.NewGuid();
            Quizzes.Add(quiz);
            return Ok(quiz);
        }

        [HttpGet("slide/{slideId}")]
        public IActionResult GetQuizzesBySlide(Guid slideId)
        {
            var slideQuizzes = Quizzes.Where(q => q.SlideId == slideId).ToList();
            return Ok(slideQuizzes);
        }

        [HttpPost("submit")]
        public IActionResult SubmitAnswer([FromBody] QuizAnswer answer)
        {
            var quiz = Quizzes.FirstOrDefault(q => q.Id == answer.QuizId);
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