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

        var slide1 = new Slide
        {
            Id = Guid.NewGuid(),
            SubjectId = subject.Id,
            Title = "What is Climate Change?",
            Content = "Climate change refers to long-term shifts in temperatures and weather patterns."
        };

        var slide2 = new Slide
        {
            Id = Guid.NewGuid(),
            SubjectId = subject.Id,
            Title = "Causes of Pollution",
            Content = "Pollution is caused by industrial waste, vehicle emissions, and plastic usage."
        };

        context.Subjects.Add(subject);
        context.Slides.AddRange(slide1, slide2);
        context.SaveChanges();
    }
}
}