namespace juniorhup.Domain.Entities
{
    public class CourseCommunityComment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int AuthorUserId { get; set; }
        public string? ContentText { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? ParentCommentId { get; set; }

        // Navigation properties
        public CourseCommunityPost Post { get; set; } = null!;
        public User AuthorUser { get; set; } = null!;
        public ICollection<CommentReaction> Reactions { get; set; } = new List<CommentReaction>();
    }
}

