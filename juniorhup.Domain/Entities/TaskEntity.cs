namespace juniorhup.Domain.Entities
{
    public class TaskEntity
    {
        public int TaskId { get; set; }
        public int CourseId { get; set; }
        public int? TrackId { get; set; }
        public int? LectureId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? Difficulty { get; set; }
        public int BasePoints { get; set; }
        public int CreatedBy { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? DueAt { get; set; }

        // Navigation properties
        public Course Course { get; set; } = null!;
        public CourseTrack? Track { get; set; }
        public Lecture? Lecture { get; set; }
        public User CreatedByUser { get; set; } = null!;
        public ICollection<TaskAssignment> Assignments { get; set; } = new List<TaskAssignment>();
    }
}

