namespace juniorhup.Domain.Entities
{
    public class CourseTrack
    {
        public int TrackId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int OrderIndex { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public Course Course { get; set; } = null!;
        public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
        public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
    }
}

