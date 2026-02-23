namespace juniorhup.Domain.Entities
{
    public class TaskSubmission
    {
        public int SubmissionId { get; set; }
        public int AssignmentId { get; set; }
        public int ChildId { get; set; }
        public DateTime SubmittedAt { get; set; }
        public string? ContentText { get; set; }
        public string? AttachmentUrl { get; set; }

        public string? ParentReviewStatus { get; set; } // pending | approved | changes_requested
        public DateTime? ParentReviewedAt { get; set; }
        public string? ParentComment { get; set; }

        public string? InstructorReviewStatus { get; set; } // pending | graded | returned
        public DateTime? InstructorReviewedAt { get; set; }
        public string? InstructorComment { get; set; }

        public string? AdminReviewStatus { get; set; } // optional escalation
        public DateTime? AdminReviewedAt { get; set; }
        public string? AdminComment { get; set; }

        public int RevisionNumber { get; set; }
        public int? FinalScore { get; set; }

        // Navigation properties
        public TaskAssignment Assignment { get; set; } = null!;
        public ChildProfile Child { get; set; } = null!;
    }
}

