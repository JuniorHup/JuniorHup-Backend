namespace juniorhup.Domain.Entities
{
    public class Badge
    {
        public int BadgeId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ConditionType { get; set; }
        public int? ThresholdValue { get; set; }

        // Navigation properties
        public ICollection<UserBadge> UserBadges { get; set; } = new List<UserBadge>();
    }
}

