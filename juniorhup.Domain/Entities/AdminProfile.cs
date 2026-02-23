namespace juniorhup.Domain.Entities
{
    public class AdminProfile
    {
        public int AdminId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? Permissions { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = string.Empty;

        // Navigation properties
        public User User { get; set; } = null!;
        public ICollection<Payment> ReviewedPayments { get; set; } = new List<Payment>();
    }
}

