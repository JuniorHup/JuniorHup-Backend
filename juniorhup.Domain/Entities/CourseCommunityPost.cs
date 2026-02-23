namespace juniorhup.Domain.Entities
{
    public class CourseCommunityPost
    {
        public int PostId { get; set; }
        public int CourseId { get; set; }
        public int AuthorUserId { get; set; }
        public string? Title { get; set; }
        public string? ContentText { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Pinned { get; set; }

        // Navigation properties
        public Course Course { get; set; } = null!;
        public User AuthorUser { get; set; } = null!;
        public ICollection<CourseCommunityComment> Comments { get; set; } = new List<CourseCommunityComment>();
        public ICollection<PostReaction> Reactions { get; set; } = new List<PostReaction>();
    }
}

