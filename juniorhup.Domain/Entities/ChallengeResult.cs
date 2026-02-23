namespace juniorhup.Domain.Entities
{
    public class ChallengeResult
    {
        public int ResultId { get; set; }
        public int ChallengeId { get; set; }
        public int WinnerChildId { get; set; }
        public string? Decision { get; set; }
        public int DecidedBy { get; set; }
        public DateTime? DecidedAt { get; set; }

        // Navigation properties
        public Challenge Challenge { get; set; } = null!;
        public ChildProfile WinnerChild { get; set; } = null!;
        public User DecidedByUser { get; set; } = null!;
    }
}

