namespace juniorhup.Domain.Entities
{
    public class InternshipApplication
    {
        public int ApplicationId { get; set; }
        public int InternshipId { get; set; }
        public int ChildId { get; set; }
        public DateTime AppliedAt { get; set; }
        public string Status { get; set; } = string.Empty; // pending | accepted | rejected | withdrawn | completed

        public string? CvUrl { get; set; }
        public string? MotivationText { get; set; }
        public int? MatchingScore { get; set; }

        public int? ReviewedByInstructorId { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string? InstructorDecision { get; set; } // approved | declined | waitlist
        public string? InstructorComment { get; set; }

        // Navigation properties
        public Internship Internship { get; set; } = null!;
        public ChildProfile Child { get; set; } = null!;
        public InstructorProfile? ReviewedByInstructor { get; set; }
        public ICollection<InternshipAssessmentAnswer> AssessmentAnswers { get; set; } = new List<InternshipAssessmentAnswer>();
        public ICollection<InternshipApplicationMessage> Messages { get; set; } = new List<InternshipApplicationMessage>();
    }
}

