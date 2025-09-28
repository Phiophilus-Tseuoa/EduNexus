using Microsoft.EntityFrameworkCore;
using EduNexusApp.Shared.Models;

namespace EduNexusApp.API.Data
{
    public class EduNexusDbContext : DbContext
    {
        public EduNexusDbContext(DbContextOptions<EduNexusDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
    }
public static class DbInitializer
{
    public static void Seed(EduNexusDbContext context)
    {
        if (context.Subjects.Any()) return; // Already seeded

        var subject = new Subject
        {
            Id = Guid.NewGuid(),
            Name = "Environmental Awareness",
            Description = "Learn about climate change, pollution, and sustainability."
        };

        var slide = new Slide
        {
            Id = Guid.NewGuid(),
            SubjectId = subject.Id,
            Title = "What is Climate Change?",
            Content = "Climate change refers to long-term shifts in temperatures and weather patterns."
        };

        var quiz1 = new Quiz
        {
            Id = Guid.NewGuid(),
            SlideId = slide.Id,
            Question = "What is a major cause of climate change?",
            Options = new List<string> { "Deforestation", "Recycling", "Rainfall", "Wind turbines" },
            CorrectOptionIndex = 0
        };

        var quiz2 = new Quiz
        {
            Id = Guid.NewGuid(),
            SlideId = slide.Id,
            Question = "Which gas contributes most to global warming?",
            Options = new List<string> { "Oxygen", "Carbon Dioxide", "Nitrogen", "Hydrogen" },
            CorrectOptionIndex = 1
        };

        context.Subjects.Add(subject);
        context.Slides.Add(slide);
        context.Quizzes.AddRange(quiz1, quiz2);
        context.SaveChanges();
    }
}
}