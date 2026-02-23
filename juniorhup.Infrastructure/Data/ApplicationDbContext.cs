using juniorhup.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace juniorhup.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Existing
        public DbSet<Product> Products { get; set; }

        // Users & Profiles
        public DbSet<User> Users { get; set; }
        public DbSet<ParentProfile> ParentProfiles { get; set; }
        public DbSet<AdminProfile> AdminProfiles { get; set; }
        public DbSet<InstructorProfile> InstructorProfiles { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<ChildProfile> ChildProfiles { get; set; }

        // Courses / Tracks / Lectures
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTrack> CourseTracks { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }

        // Task System
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }
        public DbSet<TaskSubmission> TaskSubmissions { get; set; }

        // Portfolio
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ChildSkill> ChildSkills { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMedia> ProjectMedia { get; set; }

        // Points & Badges
        public DbSet<PointsTransaction> PointsTransactions { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<UserBadge> UserBadges { get; set; }

        // Challenges
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<ChallengeParticipant> ChallengeParticipants { get; set; }
        public DbSet<ChallengeSubmission> ChallengeSubmissions { get; set; }
        public DbSet<ChallengeResult> ChallengeResults { get; set; }

        // Internship
        public DbSet<Internship> Internships { get; set; }
        public DbSet<InternshipSaved> InternshipSaved { get; set; }
        public DbSet<InternshipApplication> InternshipApplications { get; set; }
        public DbSet<InternshipAssessment> InternshipAssessments { get; set; }
        public DbSet<InternshipAssessmentQuestion> InternshipAssessmentQuestions { get; set; }
        public DbSet<InternshipAssessmentAnswer> InternshipAssessmentAnswers { get; set; }
        public DbSet<InternshipApplicationMessage> InternshipApplicationMessages { get; set; }
        public DbSet<InternshipTask> InternshipTasks { get; set; }
        public DbSet<InternshipTaskSubmission> InternshipTaskSubmissions { get; set; }

        // Course Community
        public DbSet<CourseCommunityPost> CourseCommunityPosts { get; set; }
        public DbSet<CourseCommunityComment> CourseCommunityComments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<PostReaction> PostReactions { get; set; }
        public DbSet<CommentReaction> CommentReactions { get; set; }

        // Subscription & Payments
        public DbSet<Package> Packages { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // -- Existing Product seed --
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().HasData(
                new Product("Test Product 1", "Description 1", 19.99m) { Id = 1 },
                new Product("Test Product 2", "Description 2", 29.99m) { Id = 2 }
            );

            // ----------------------------------------------
            // USERS & PROFILES
            // ----------------------------------------------

            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(u => u.UserId);
                e.Property(u => u.Email).IsRequired();
                e.Property(u => u.PasswordHash).IsRequired();
                e.Property(u => u.Role).IsRequired();
            });

            modelBuilder.Entity<ParentProfile>(e =>
            {
                e.HasKey(p => p.ParentId);
                e.Property(p => p.ParentId).ValueGeneratedNever();
                e.HasOne(p => p.User)
                    .WithOne(u => u.ParentProfile)
                    .HasForeignKey<ParentProfile>(p => p.ParentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AdminProfile>(e =>
            {
                e.HasKey(a => a.AdminId);
                e.Property(a => a.AdminId).ValueGeneratedNever();
                e.HasOne(a => a.User)
                    .WithOne(u => u.AdminProfile)
                    .HasForeignKey<AdminProfile>(a => a.AdminId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<InstructorProfile>(e =>
            {
                e.HasKey(i => i.InstructorId);
                e.Property(i => i.InstructorId).ValueGeneratedNever();
                e.HasOne(i => i.User)
                    .WithOne(u => u.InstructorProfile)
                    .HasForeignKey<InstructorProfile>(i => i.InstructorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Avatar>(e =>
            {
                e.HasKey(a => a.AvatarId);
            });

            modelBuilder.Entity<ChildProfile>(e =>
            {
                e.HasKey(c => c.ChildId);
                e.Property(c => c.ChildId).ValueGeneratedNever();
                e.HasOne(c => c.User)
                    .WithOne(u => u.ChildProfile)
                    .HasForeignKey<ChildProfile>(c => c.ChildId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(c => c.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(c => c.ParentId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(c => c.Avatar)
                    .WithMany(a => a.ChildProfiles)
                    .HasForeignKey(c => c.AvatarId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // ----------------------------------------------
            // COURSES / TRACKS / LECTURES
            // ----------------------------------------------

            modelBuilder.Entity<Course>(e =>
            {
                e.HasKey(c => c.CourseId);
                e.HasOne(c => c.Instructor)
                    .WithMany(i => i.Courses)
                    .HasForeignKey(c => c.InstructorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CourseTrack>(e =>
            {
                e.HasKey(ct => ct.TrackId);
                e.HasOne(ct => ct.Course)
                    .WithMany(c => c.Tracks)
                    .HasForeignKey(ct => ct.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Lecture>(e =>
            {
                e.HasKey(l => l.LectureId);
                e.HasOne(l => l.Track)
                    .WithMany(t => t.Lectures)
                    .HasForeignKey(l => l.TrackId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CourseEnrollment>(e =>
            {
                e.HasKey(ce => ce.EnrollmentId);
                e.HasOne(ce => ce.Child)
                    .WithMany(c => c.Enrollments)
                    .HasForeignKey(ce => ce.ChildId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(ce => ce.Course)
                    .WithMany(c => c.Enrollments)
                    .HasForeignKey(ce => ce.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ----------------------------------------------
            // TASK SYSTEM
            // ----------------------------------------------

            modelBuilder.Entity<TaskEntity>(e =>
            {
                e.HasKey(t => t.TaskId);
                e.HasOne(t => t.Course)
                    .WithMany(c => c.Tasks)
                    .HasForeignKey(t => t.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(t => t.Track)
                    .WithMany(ct => ct.Tasks)
                    .HasForeignKey(t => t.TrackId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(t => t.Lecture)
                    .WithMany(l => l.Tasks)
                    .HasForeignKey(t => t.LectureId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(t => t.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(t => t.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TaskAssignment>(e =>
            {
                e.HasKey(ta => ta.AssignmentId);
                e.HasOne(ta => ta.Task)
                    .WithMany(t => t.Assignments)
                    .HasForeignKey(ta => ta.TaskId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(ta => ta.Child)
                    .WithMany(c => c.TaskAssignments)
                    .HasForeignKey(ta => ta.ChildId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(ta => ta.AssignedByUser)
                    .WithMany()
                    .HasForeignKey(ta => ta.AssignedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TaskSubmission>(e =>
            {
                e.HasKey(ts => ts.SubmissionId);
                e.HasOne(ts => ts.Assignment)
                    .WithMany(ta => ta.Submissions)
                    .HasForeignKey(ts => ts.AssignmentId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(ts => ts.Child)
                    .WithMany()
                    .HasForeignKey(ts => ts.ChildId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ----------------------------------------------
            // PORTFOLIO
            // ----------------------------------------------

            modelBuilder.Entity<Portfolio>(e =>
            {
                e.HasKey(p => p.PortfolioId);
                e.HasOne(p => p.Child)
                    .WithMany(c => c.Portfolios)
                    .HasForeignKey(p => p.ChildId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Skill>(e =>
            {
                e.HasKey(s => s.SkillId);
            });

            modelBuilder.Entity<ChildSkill>(e =>
            {
                e.HasKey(cs => cs.ChildSkillId);
                e.HasOne(cs => cs.Portfolio)
                    .WithMany(p => p.ChildSkills)
                    .HasForeignKey(cs => cs.PortfolioId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(cs => cs.Skill)
                    .WithMany(s => s.ChildSkills)
                    .HasForeignKey(cs => cs.SkillId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Project>(e =>
            {
                e.HasKey(p => p.ProjectId);
                e.HasOne(p => p.Portfolio)
                    .WithMany(po => po.Projects)
                    .HasForeignKey(p => p.PortfolioId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProjectMedia>(e =>
            {
                e.HasKey(pm => pm.MediaId);
                e.HasOne(pm => pm.Project)
                    .WithMany(p => p.Media)
                    .HasForeignKey(pm => pm.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ----------------------------------------------
            // POINTS & BADGES
            // ----------------------------------------------

            modelBuilder.Entity<PointsTransaction>(e =>
            {
                e.HasKey(pt => pt.TransactionId);
                e.HasOne(pt => pt.User)
                    .WithMany(u => u.PointsTransactions)
                    .HasForeignKey(pt => pt.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Badge>(e =>
            {
                e.HasKey(b => b.BadgeId);
            });

            modelBuilder.Entity<UserBadge>(e =>
            {
                e.HasKey(ub => ub.UserBadgeId);
                e.HasOne(ub => ub.User)
                    .WithMany(u => u.UserBadges)
                    .HasForeignKey(ub => ub.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(ub => ub.Badge)
                    .WithMany(b => b.UserBadges)
                    .HasForeignKey(ub => ub.BadgeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ----------------------------------------------
            // CHALLENGES
            // ----------------------------------------------

            modelBuilder.Entity<Challenge>(e =>
            {
                e.HasKey(c => c.ChallengeId);
                e.HasOne(c => c.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(c => c.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ChallengeParticipant>(e =>
            {
                e.HasKey(cp => cp.Id);
                e.HasOne(cp => cp.Challenge)
                    .WithMany(c => c.Participants)
                    .HasForeignKey(cp => cp.ChallengeId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(cp => cp.Child)
                    .WithMany(c => c.ChallengeParticipations)
                    .HasForeignKey(cp => cp.ChildId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ChallengeSubmission>(e =>
            {
                e.HasKey(cs => cs.ChallengeSubmissionId);
                e.HasOne(cs => cs.Challenge)
                    .WithMany(c => c.Submissions)
                    .HasForeignKey(cs => cs.ChallengeId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(cs => cs.Child)
                    .WithMany()
                    .HasForeignKey(cs => cs.ChildId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ChallengeResult>(e =>
            {
                e.HasKey(cr => cr.ResultId);
                e.HasOne(cr => cr.Challenge)
                    .WithMany(c => c.Results)
                    .HasForeignKey(cr => cr.ChallengeId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(cr => cr.WinnerChild)
                    .WithMany()
                    .HasForeignKey(cr => cr.WinnerChildId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(cr => cr.DecidedByUser)
                    .WithMany()
                    .HasForeignKey(cr => cr.DecidedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ----------------------------------------------
            // INTERNSHIP
            // ----------------------------------------------

            modelBuilder.Entity<Internship>(e =>
            {
                e.HasKey(i => i.InternshipId);
                e.HasOne(i => i.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(i => i.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<InternshipSaved>(e =>
            {
                e.HasKey(s => s.SavedId);
                e.HasOne(s => s.Child)
                    .WithMany(c => c.SavedInternships)
                    .HasForeignKey(s => s.ChildId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(s => s.Internship)
                    .WithMany(i => i.SavedByChildren)
                    .HasForeignKey(s => s.InternshipId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<InternshipApplication>(e =>
            {
                e.HasKey(a => a.ApplicationId);
                e.HasOne(a => a.Internship)
                    .WithMany(i => i.Applications)
                    .HasForeignKey(a => a.InternshipId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(a => a.Child)
                    .WithMany(c => c.InternshipApplications)
                    .HasForeignKey(a => a.ChildId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(a => a.ReviewedByInstructor)
                    .WithMany(i => i.ReviewedApplications)
                    .HasForeignKey(a => a.ReviewedByInstructorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<InternshipAssessment>(e =>
            {
                e.HasKey(a => a.AssessmentId);
                e.HasOne(a => a.Internship)
                    .WithMany(i => i.Assessments)
                    .HasForeignKey(a => a.InternshipId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<InternshipAssessmentQuestion>(e =>
            {
                e.HasKey(q => q.QuestionId);
                e.HasOne(q => q.Assessment)
                    .WithMany(a => a.Questions)
                    .HasForeignKey(q => q.AssessmentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<InternshipAssessmentAnswer>(e =>
            {
                e.HasKey(a => a.AnswerId);
                e.HasOne(a => a.Application)
                    .WithMany(app => app.AssessmentAnswers)
                    .HasForeignKey(a => a.ApplicationId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(a => a.Question)
                    .WithMany(q => q.Answers)
                    .HasForeignKey(a => a.QuestionId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(a => a.Child)
                    .WithMany()
                    .HasForeignKey(a => a.ChildId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<InternshipApplicationMessage>(e =>
            {
                e.HasKey(m => m.MessageId);
                e.HasOne(m => m.Application)
                    .WithMany(a => a.Messages)
                    .HasForeignKey(m => m.ApplicationId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(m => m.SenderUser)
                    .WithMany()
                    .HasForeignKey(m => m.SenderUserId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(m => m.ReceiverUser)
                    .WithMany()
                    .HasForeignKey(m => m.ReceiverUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<InternshipTask>(e =>
            {
                e.HasKey(t => t.InternshipTaskId);
                e.HasOne(t => t.Internship)
                    .WithMany(i => i.InternshipTasks)
                    .HasForeignKey(t => t.InternshipId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<InternshipTaskSubmission>(e =>
            {
                e.HasKey(s => s.InternshipTaskSubmissionId);
                e.HasOne(s => s.InternshipTask)
                    .WithMany(t => t.Submissions)
                    .HasForeignKey(s => s.InternshipTaskId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(s => s.Child)
                    .WithMany()
                    .HasForeignKey(s => s.ChildId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(s => s.ReviewedByUser)
                    .WithMany()
                    .HasForeignKey(s => s.ReviewedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ----------------------------------------------
            // COURSE COMMUNITY
            // ----------------------------------------------

            modelBuilder.Entity<CourseCommunityPost>(e =>
            {
                e.HasKey(p => p.PostId);
                e.HasOne(p => p.Course)
                    .WithMany(c => c.CommunityPosts)
                    .HasForeignKey(p => p.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(p => p.AuthorUser)
                    .WithMany()
                    .HasForeignKey(p => p.AuthorUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CourseCommunityComment>(e =>
            {
                e.HasKey(c => c.CommentId);
                e.HasOne(c => c.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(c => c.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
                e.HasOne(c => c.AuthorUser)
                    .WithMany()
                    .HasForeignKey(c => c.AuthorUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Reaction>(e =>
            {
                e.HasKey(r => r.ReactionId);
            });

            modelBuilder.Entity<PostReaction>(e =>
            {
                e.HasKey(pr => pr.Id);
                e.HasOne(pr => pr.Post)
                    .WithMany(p => p.Reactions)
                    .HasForeignKey(pr => pr.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
                e.HasOne(pr => pr.User)
                    .WithMany()
                    .HasForeignKey(pr => pr.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(pr => pr.Reaction)
                    .WithMany(r => r.PostReactions)
                    .HasForeignKey(pr => pr.ReactionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CommentReaction>(e =>
            {
                e.HasKey(cr => cr.Id);
                e.HasOne(cr => cr.Comment)
                    .WithMany(c => c.Reactions)
                    .HasForeignKey(cr => cr.CommentId)
                    .OnDelete(DeleteBehavior.Cascade);
                e.HasOne(cr => cr.User)
                    .WithMany()
                    .HasForeignKey(cr => cr.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(cr => cr.Reaction)
                    .WithMany(r => r.CommentReactions)
                    .HasForeignKey(cr => cr.ReactionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ----------------------------------------------
            // SUBSCRIPTION & PAYMENTS
            // ----------------------------------------------

            modelBuilder.Entity<Package>(e =>
            {
                e.HasKey(p => p.PackageId);
                e.Property(p => p.PriceDecimal).HasPrecision(18, 2);
            });

            modelBuilder.Entity<UserSubscription>(e =>
            {
                e.HasKey(us => us.SubscriptionId);
                e.HasOne(us => us.User)
                    .WithMany(u => u.UserSubscriptions)
                    .HasForeignKey(us => us.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(us => us.Package)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(us => us.PackageId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Payment>(e =>
            {
                e.HasKey(p => p.PaymentId);
                e.Property(p => p.AmountDecimal).HasPrecision(18, 2);
                e.HasOne(p => p.User)
                    .WithMany(u => u.Payments)
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(p => p.Subscription)
                    .WithMany(s => s.Payments)
                    .HasForeignKey(p => p.SubscriptionId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(p => p.ReviewedByAdmin)
                    .WithMany(a => a.ReviewedPayments)
                    .HasForeignKey(p => p.ReviewedByAdminId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

