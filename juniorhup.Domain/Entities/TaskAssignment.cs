namespace juniorhup.Domain.Entities
{
    public class TaskAssignment
    {
        public int AssignmentId { get; set; }
        public int TaskId { get; set; }
        public int ChildId { get; set; }
        public int AssignedBy { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? DueAt { get; set; }
        public string Status { get; set; } = string.Empty; // not_started | in_progress | submitted | reviewed

        // Navigation properties
        public TaskEntity Task { get; set; } = null!;
        public ChildProfile Child { get; set; } = null!;
        public User AssignedByUser { get; set; } = null!;
        public ICollection<TaskSubmission> Submissions { get; set; } = new List<TaskSubmission>();
    }
}

