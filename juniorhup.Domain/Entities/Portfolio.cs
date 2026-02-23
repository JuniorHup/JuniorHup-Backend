namespace juniorhup.Domain.Entities
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public int ChildId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public ChildProfile Child { get; set; } = null!;
        public ICollection<ChildSkill> ChildSkills { get; set; } = new List<ChildSkill>();
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}

