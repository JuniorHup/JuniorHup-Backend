namespace juniorhup.Domain.Entities
{
    public class Lecture
    {
        public int LectureId { get; set; }
        public int TrackId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? ContentUrl { get; set; }
        public string ContentType { get; set; } = string.Empty; // video | pdf | link | text
        public int OrderIndex { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public CourseTrack Track { get; set; } = null!;
        public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
    }
}

