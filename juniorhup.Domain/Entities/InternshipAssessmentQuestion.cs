namespace juniorhup.Domain.Entities
{
    public class InternshipAssessmentQuestion
    {
        public int QuestionId { get; set; }
        public int AssessmentId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string QuestionType { get; set; } = string.Empty; // text | mcq | rating
        public int OrderIndex { get; set; }

        // Navigation properties
        public InternshipAssessment Assessment { get; set; } = null!;
        public ICollection<InternshipAssessmentAnswer> Answers { get; set; } = new List<InternshipAssessmentAnswer>();
    }
}

