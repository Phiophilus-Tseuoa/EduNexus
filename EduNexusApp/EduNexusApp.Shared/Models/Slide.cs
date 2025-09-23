namespace EduNexusApp.Shared.Models
{
    public class Slide
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FileUrl { get; set; }
        public Guid SubjectId { get; set; }
        public string Content { get; set; }
    }
}