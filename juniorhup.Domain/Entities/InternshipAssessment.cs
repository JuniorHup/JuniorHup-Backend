namespace juniorhup.Domain.Entities
{
    public class InternshipAssessment
    {
        public int AssessmentId { get; set; }
        public int InternshipId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public Internship Internship { get; set; } = null!;
        public ICollection<InternshipAssessmentQuestion> Questions { get; set; } = new List<InternshipAssessmentQuestion>();
    }
}

