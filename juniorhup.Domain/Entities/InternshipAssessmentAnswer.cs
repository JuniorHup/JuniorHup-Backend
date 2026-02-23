namespace juniorhup.Domain.Entities
{
    public class InternshipAssessmentAnswer
    {
        public int AnswerId { get; set; }
        public int ApplicationId { get; set; }
        public int QuestionId { get; set; }
        public int ChildId { get; set; }
        public string? AnswerText { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public InternshipApplication Application { get; set; } = null!;
        public InternshipAssessmentQuestion Question { get; set; } = null!;
        public ChildProfile Child { get; set; } = null!;
    }
}

