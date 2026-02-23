namespace juniorhup.Domain.Entities
{
    public class ChildSkill
    {
        public int ChildSkillId { get; set; }
        public int PortfolioId { get; set; }
        public int SkillId { get; set; }
        public int Level { get; set; }
        public string? Notes { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public Portfolio Portfolio { get; set; } = null!;
        public Skill Skill { get; set; } = null!;
    }
}

