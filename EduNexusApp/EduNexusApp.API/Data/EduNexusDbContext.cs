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
}