namespace juniorhup.Domain.Entities
{
    public class InstructorProfile
    {
        public int InstructorId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public string Phone { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = string.Empty;

        // Navigation properties
        public User User { get; set; } = null!;
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<InternshipApplication> ReviewedApplications { get; set; } = new List<InternshipApplication>();
    }
}

