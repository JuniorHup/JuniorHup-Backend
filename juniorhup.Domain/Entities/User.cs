namespace juniorhup.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // parent | child | admin | instructor
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = string.Empty;

        // Navigation properties
        public ParentProfile? ParentProfile { get; set; }
        public AdminProfile? AdminProfile { get; set; }
        public InstructorProfile? InstructorProfile { get; set; }
        public ChildProfile? ChildProfile { get; set; }
        public ICollection<PointsTransaction> PointsTransactions { get; set; } = new List<PointsTransaction>();
        public ICollection<UserBadge> UserBadges { get; set; } = new List<UserBadge>();
        public ICollection<UserSubscription> UserSubscriptions { get; set; } = new List<UserSubscription>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}

