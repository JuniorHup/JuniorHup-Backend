namespace juniorhup.Domain.Entities
{
    public class ParentProfile
    {
        public int ParentId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string ApprovalMode { get; set; } = string.Empty;
        public string? NotificationPreferences { get; set; }

        // Navigation properties
        public User User { get; set; } = null!;
        public ICollection<ChildProfile> Children { get; set; } = new List<ChildProfile>();
    }
}

