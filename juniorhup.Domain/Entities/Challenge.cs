namespace juniorhup.Domain.Entities
{
    public class Challenge
    {
        public int ChallengeId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Difficulty { get; set; }
        public int BonusPoints { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Deadline { get; set; }
        public string Status { get; set; } = string.Empty;

        // Navigation properties
        public User CreatedByUser { get; set; } = null!;
        public ICollection<ChallengeParticipant> Participants { get; set; } = new List<ChallengeParticipant>();
        public ICollection<ChallengeSubmission> Submissions { get; set; } = new List<ChallengeSubmission>();
        public ICollection<ChallengeResult> Results { get; set; } = new List<ChallengeResult>();
    }
}

