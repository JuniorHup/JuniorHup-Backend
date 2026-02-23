namespace juniorhup.Domain.Entities
{
    public class ChallengeSubmission
    {
        public int ChallengeSubmissionId { get; set; }
        public int ChallengeId { get; set; }
        public int ChildId { get; set; }
        public DateTime SubmittedAt { get; set; }
        public string? ContentText { get; set; }
        public string? AttachmentUrl { get; set; }

        // Navigation properties
        public Challenge Challenge { get; set; } = null!;
        public ChildProfile Child { get; set; } = null!;
    }
}

