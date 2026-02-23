namespace juniorhup.Domain.Entities
{
    public class PostReaction
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int ReactionId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public CourseCommunityPost Post { get; set; } = null!;
        public User User { get; set; } = null!;
        public Reaction Reaction { get; set; } = null!;
    }
}

