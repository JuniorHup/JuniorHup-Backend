namespace juniorhup.Domain.Entities
{
    public class ProjectMedia
    {
        public int MediaId { get; set; }
        public int ProjectId { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public string MediaType { get; set; } = string.Empty; // image | video | document | link
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public Project Project { get; set; } = null!;
    }
}

