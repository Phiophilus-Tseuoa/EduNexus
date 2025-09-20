namespace EduNexusApp.Shared.Models
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<User> EnrolledStudents { get; set; } = new();
    }
}