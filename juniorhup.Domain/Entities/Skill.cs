namespace juniorhup.Domain.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Category { get; set; }
        public string? Description { get; set; }

        // Navigation properties
        public ICollection<ChildSkill> ChildSkills { get; set; } = new List<ChildSkill>();
    }
}

