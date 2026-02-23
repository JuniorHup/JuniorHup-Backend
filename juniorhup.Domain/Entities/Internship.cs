namespace juniorhup.Domain.Entities
{
    public class Internship
    {
        public int InternshipId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Company { get; set; }
        public string? Location { get; set; }
        public string? RequiredSkills { get; set; }
        public string Status { get; set; } = string.Empty; // open | closed | archived
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public User CreatedByUser { get; set; } = null!;
        public ICollection<InternshipSaved> SavedByChildren { get; set; } = new List<InternshipSaved>();
        public ICollection<InternshipApplication> Applications { get; set; } = new List<InternshipApplication>();
        public ICollection<InternshipAssessment> Assessments { get; set; } = new List<InternshipAssessment>();
        public ICollection<InternshipTask> InternshipTasks { get; set; } = new List<InternshipTask>();
    }
}

