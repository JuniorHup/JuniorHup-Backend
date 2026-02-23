namespace juniorhup.Domain.Entities
{
    public class ChildProfile
    {
        public int ChildId { get; set; }
        public int ParentId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? SchoolName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? NationalId { get; set; }
        public int? AvatarId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = string.Empty;

        // Navigation properties
        public User User { get; set; } = null!;
        public ParentProfile Parent { get; set; } = null!;
        public Avatar? Avatar { get; set; }
        public ICollection<CourseEnrollment> Enrollments { get; set; } = new List<CourseEnrollment>();
        public ICollection<TaskAssignment> TaskAssignments { get; set; } = new List<TaskAssignment>();
        public ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
        public ICollection<ChallengeParticipant> ChallengeParticipations { get; set; } = new List<ChallengeParticipant>();
        public ICollection<InternshipSaved> SavedInternships { get; set; } = new List<InternshipSaved>();
        public ICollection<InternshipApplication> InternshipApplications { get; set; } = new List<InternshipApplication>();
    }
}

