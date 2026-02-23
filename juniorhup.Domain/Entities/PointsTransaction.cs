namespace juniorhup.Domain.Entities
{
    public class PointsTransaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public string SourceType { get; set; } = string.Empty; // task | challenge | bonus | badge | internship
        public int SourceId { get; set; }
        public int Points { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public User User { get; set; } = null!;
    }
}

