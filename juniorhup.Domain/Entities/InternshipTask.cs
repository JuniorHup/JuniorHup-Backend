namespace juniorhup.Domain.Entities
{
    public class InternshipTask
    {
        public int InternshipTaskId { get; set; }
        public int InternshipId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? DueAt { get; set; }

        // Navigation properties
        public Internship Internship { get; set; } = null!;
        public ICollection<InternshipTaskSubmission> Submissions { get; set; } = new List<InternshipTaskSubmission>();
    }
}

