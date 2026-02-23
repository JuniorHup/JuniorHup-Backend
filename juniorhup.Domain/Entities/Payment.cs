namespace juniorhup.Domain.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public int SubscriptionId { get; set; }
        public decimal AmountDecimal { get; set; }
        public string? InstapayAccount { get; set; }
        public string? PayerAccountIdentifier { get; set; }
        public string? ReceiptImageUrl { get; set; }
        public string Status { get; set; } = string.Empty; // pending_review | approved | rejected
        public int? ReviewedByAdminId { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string? ReviewComment { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public User User { get; set; } = null!;
        public UserSubscription Subscription { get; set; } = null!;
        public AdminProfile? ReviewedByAdmin { get; set; }
    }
}

