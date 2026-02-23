namespace juniorhup.Domain.Entities
{
    public class UserBadge
    {
        public int UserBadgeId { get; set; }
        public int UserId { get; set; }
        public int BadgeId { get; set; }
        public DateTime EarnedAt { get; set; }

        // Navigation properties
        public User User { get; set; } = null!;
        public Badge Badge { get; set; } = null!;
    }
}

