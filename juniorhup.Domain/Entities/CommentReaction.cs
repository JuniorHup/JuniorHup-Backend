namespace juniorhup.Domain.Entities
{
    public class CommentReaction
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int ReactionId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public CourseCommunityComment Comment { get; set; } = null!;
        public User User { get; set; } = null!;
        public Reaction Reaction { get; set; } = null!;
    }
}

