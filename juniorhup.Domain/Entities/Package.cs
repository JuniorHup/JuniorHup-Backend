namespace juniorhup.Domain.Entities
{
    public class Package
    {
        public int PackageId { get; set; }
        public string Name { get; set; } = string.Empty; // e.g. Basic, Pro, Family
        public string? Description { get; set; }
        public decimal PriceDecimal { get; set; }
        public string BillingPeriod { get; set; } = string.Empty; // monthly | yearly | one_time
        public string? Features { get; set; } // JSON or plain list
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public ICollection<UserSubscription> Subscriptions { get; set; } = new List<UserSubscription>();
    }
}

