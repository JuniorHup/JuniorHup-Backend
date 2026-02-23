namespace juniorhup.Domain.Entities
{
    public class Reaction
    {
        public int ReactionId { get; set; }
        public string Name { get; set; } = string.Empty; // like | love | clap...
        public string? Icon { get; set; }

        // Navigation properties
        public ICollection<PostReaction> PostReactions { get; set; } = new List<PostReaction>();
        public ICollection<CommentReaction> CommentReactions { get; set; } = new List<CommentReaction>();
    }
}

