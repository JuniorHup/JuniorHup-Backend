namespace juniorhup.Domain.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Level { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; // draft | published | archived
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? WhatsappLink { get; set; }
        public string? WhatsappQrImageUrl { get; set; }

        // Navigation properties
        public InstructorProfile Instructor { get; set; } = null!;
        public ICollection<CourseTrack> Tracks { get; set; } = new List<CourseTrack>();
        public ICollection<CourseEnrollment> Enrollments { get; set; } = new List<CourseEnrollment>();
        public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
        public ICollection<CourseCommunityPost> CommunityPosts { get; set; } = new List<CourseCommunityPost>();
    }
}

