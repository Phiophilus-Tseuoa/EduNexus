namespace EduNexusApp.Shared.Models
{
    public class Quiz
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public List<string> Options { get; set; } = new();
        public int CorrectOptionIndex { get; set; }
        public Guid SlideId { get; set; }
    }
}