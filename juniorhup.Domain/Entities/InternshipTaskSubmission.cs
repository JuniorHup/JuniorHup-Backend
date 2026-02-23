namespace juniorhup.Domain.Entities
{
    public class InternshipTaskSubmission
    {
        public int InternshipTaskSubmissionId { get; set; }
        public int InternshipTaskId { get; set; }
        public int ChildId { get; set; }
        public DateTime SubmittedAt { get; set; }
        public string? ContentText { get; set; }
        public string? AttachmentUrl { get; set; }
        public string Status { get; set; } = string.Empty; // pending | reviewed
        public int? ReviewedBy { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string? Comment { get; set; }

        // Navigation properties
        public InternshipTask InternshipTask { get; set; } = null!;
        public ChildProfile Child { get; set; } = null!;
        public User? ReviewedByUser { get; set; }
    }
}

