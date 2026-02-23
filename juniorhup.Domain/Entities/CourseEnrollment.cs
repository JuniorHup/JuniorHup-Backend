namespace juniorhup.Domain.Entities
{
    public class CourseEnrollment
    {
        public int EnrollmentId { get; set; }
        public int ChildId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrolledAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int ProgressPercent { get; set; }

        // Navigation properties
        public ChildProfile Child { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}

