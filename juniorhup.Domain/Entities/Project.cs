namespace juniorhup.Domain.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public int PortfolioId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public Portfolio Portfolio { get; set; } = null!;
        public ICollection<ProjectMedia> Media { get; set; } = new List<ProjectMedia>();
    }
}

