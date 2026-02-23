namespace juniorhup.Domain.Entities
{
    public class InternshipSaved
    {
        public int SavedId { get; set; }
        public int ChildId { get; set; }
        public int InternshipId { get; set; }
        public DateTime SavedAt { get; set; }

        // Navigation properties
        public ChildProfile Child { get; set; } = null!;
        public Internship Internship { get; set; } = null!;
    }
}

