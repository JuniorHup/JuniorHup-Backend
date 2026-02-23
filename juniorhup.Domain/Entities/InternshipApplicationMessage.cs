namespace juniorhup.Domain.Entities
{
    public class InternshipApplicationMessage
    {
        public int MessageId { get; set; }
        public int ApplicationId { get; set; }
        public int SenderUserId { get; set; }
        public int ReceiverUserId { get; set; }
        public string MessageText { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }

        // Navigation properties
        public InternshipApplication Application { get; set; } = null!;
        public User SenderUser { get; set; } = null!;
        public User ReceiverUser { get; set; } = null!;
    }
}

