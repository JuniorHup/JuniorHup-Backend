namespace juniorhup.Domain.Entities
{
    public class ChallengeParticipant
    {
        public int Id { get; set; }
        public int ChallengeId { get; set; }
        public int ChildId { get; set; }
        public DateTime JoinedAt { get; set; }

        // Navigation properties
        public Challenge Challenge { get; set; } = null!;
        public ChildProfile Child { get; set; } = null!;
    }
}

