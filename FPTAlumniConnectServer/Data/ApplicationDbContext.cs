using FPTAlumniConnectServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FPTAlumniConnectServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationSetting> NotificationSettings { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostReport> PostReports { get; set; }
        public DbSet<PrivacySetting> PrivacySettings { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<UserJoinEvent> UserJoinEvents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<GroupChat> GroupChats { get; set; }
        public DbSet<GroupChatMember> GroupChatMembers { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<MentorshipFeedback> MentorshipFeedbacks { get; set; }
        public DbSet<MentorshipRequest> MentorshipRequests { get; set; }
        public DbSet<MessageGroupChat> MessageGroupChats { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(15);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(320);
                entity.Property(e => e.HashPassword).IsRequired().HasMaxLength(128);
                entity.Property(e => e.Major).HasMaxLength(100);
                modelBuilder.Entity<User>().HasData(
                     new User
                     {
                         Id = 1,
                         FirstName = "Huy",
                         LastName = "Nguyễn",
                         HashPassword = "E10ADC3949BA59ABBE56E057F20F883E",
                         Email = "huyng.1801@gmail.com",
                         EmailConfirmed = false,
                         ProfilePictureUrl = null,
                         Role = RoleEnum.Admin,
                         EducationHistory = null,
                         Major = null,
                         IsMentor = false,
                         IsActive = true,
                         CreatedAt = DateTime.UtcNow,
                         UpdatedAt = DateTime.UtcNow
                     },
                     new User
                     {
                         Id = 2,
                         FirstName = "Mai",
                         LastName = "Trần",
                         HashPassword = "E10ADC3949BA59ABBE56E057F20F883E",
                         Email = "mai.t@gmail.com",
                         EmailConfirmed = false,
                         ProfilePictureUrl = null,
                         Role = RoleEnum.Recruiter,
                         EducationHistory = null,
                         Major = null,
                         IsMentor = false,
                         IsActive = true,
                         CreatedAt = DateTime.UtcNow,
                         UpdatedAt = DateTime.UtcNow
                     },
                     new User
                     {
                         Id = 3,
                         FirstName = "Lan",
                         LastName = "Lê",
                         HashPassword = "E10ADC3949BA59ABBE56E057F20F883E",
                         Email = "lan.le@example.com",
                         EmailConfirmed = true,
                         ProfilePictureUrl = null,
                         Role = RoleEnum.Alumni,
                         EducationHistory = "Computer Science",
                         Major = "Software Engineering",
                         IsMentor = true,
                         IsActive = true,
                         CreatedAt = DateTime.UtcNow,
                         UpdatedAt = DateTime.UtcNow
                     },
                     new User
                     {
                         Id = 4,
                         FirstName = "Toan",
                         LastName = "Phạm",
                         HashPassword = "E10ADC3949BA59ABBE56E057F20F883E",
                         Email = "toan.pham@example.com",
                         EmailConfirmed = false,
                         ProfilePictureUrl = null,
                         Role = RoleEnum.Student,
                         EducationHistory = "Mathematics",
                         Major = "Data Science",
                         IsMentor = false,
                         IsActive = true,
                         CreatedAt = DateTime.UtcNow,
                         UpdatedAt = DateTime.UtcNow
                     },
                     new User
                     {
                         Id = 5,
                         FirstName = "An",
                         LastName = "Nguyễn",
                         HashPassword = "E10ADC3949BA59ABBE56E057F20F883E",
                         Email = "an.nguyen@example.com",
                         EmailConfirmed = true,
                         ProfilePictureUrl = null,
                         Role = RoleEnum.Teacher,
                         EducationHistory = "Physics",
                         Major = "Education",
                         IsMentor = true,
                         IsActive = true,
                         CreatedAt = DateTime.UtcNow,
                         UpdatedAt = DateTime.UtcNow
                     }
                 );
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CategoryName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.RecipientUser)
                    .WithMany(u => u.ReceivedNotifications)
                    .HasForeignKey(e => e.RecipientUserId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.SenderUser)
                    .WithMany(u => u.SentNotifications)
                    .HasForeignKey(e => e.SenderUserId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<NotificationSetting>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User)
                     .WithMany(u => u.NotificationSettings)
                     .HasForeignKey(e => e.UserId)
                     .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Content).HasColumnType("NTEXT").IsRequired();
                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Posts)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(p => p.User)
                     .WithMany(c => c.Posts)
                     .HasForeignKey(p => p.UserId)
                     .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<PostReport>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(pr => pr.Post)
                    .WithMany(p => p.PostReports)
                    .HasForeignKey(pr => pr.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(pr => pr.User)
                    .WithMany(p => p.PostReports)
                    .HasForeignKey(pr => pr.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PrivacySetting>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(ps => ps.User)
                    .WithMany(u => u.PrivacySettings)
                    .HasForeignKey(ps => ps.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.EventName).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.HasOne(s => s.User)
                         .WithMany(u => u.Events)
                         .HasForeignKey(s => s.UserId)
                         .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserJoinEvent>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Content).IsRequired();
                entity.HasOne(uje => uje.Event)
                    .WithMany(e => e.UserJoinEvents)
                    .HasForeignKey(uje => uje.EventId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

       
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Content).HasColumnType("NTEXT").IsRequired();
                entity.HasOne(c => c.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(c => c.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(c => c.User)
                   .WithMany(p => p.Comments)
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<GroupChat>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.GroupName).IsRequired().HasMaxLength(150);
                entity.HasOne(c => c.User)
                      .WithMany(p => p.GroupChats)
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<GroupChatMember>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(gcm => gcm.GroupChat)
                    .WithMany(gc => gc.GroupChatMembers)
                    .HasForeignKey(gcm => gcm.GroupChatId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(gcm => gcm.User)
                    .WithMany(gc => gc.GroupChatMembers)
                    .HasForeignKey(gcm => gcm.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(gcm => gcm.AddedByUser)
                    .WithMany(gc => gc.AddedGroupChatMembers)
                    .HasForeignKey(gcm => gcm.AddedByUserId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<MessageGroupChat>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Content).IsRequired().HasColumnType("NTEXT");
                entity.HasOne(mgc => mgc.GroupChatMember)
                    .WithMany(gc => gc.MessageGroupChats)
                    .HasForeignKey(mgc => mgc.MemberId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<JobPost>(entity =>
            {
                entity.HasKey(e => e.JobPostID);
                entity.Property(e => e.JobTitle).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Salary).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Location).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Experience).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Experience).IsRequired().HasColumnType("NTEXT");
                entity.HasOne(jp => jp.User)
                    .WithMany(u => u.JobPosts)
                    .HasForeignKey(jp => jp.UserID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<JobApplication>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ApplicantName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CoverLetter).IsRequired().HasMaxLength(500);
                entity.HasOne(ja => ja.JobPost)
                    .WithMany(u => u.JobApplications)
                    .HasForeignKey(ja => ja.JobPostId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(ja => ja.User)
                    .WithMany(u => u.JobApplications)
                    .HasForeignKey(ja => ja.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
            });


            modelBuilder.Entity<MentorshipRequest>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RequestMessage).IsRequired().HasColumnType("NTEXT");
                entity.HasOne(mr => mr.Mentor)
                    .WithMany(u => u.MentorOfMentorshipRequests)
                    .HasForeignKey(mr => mr.MentorId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(mr => mr.Student)
                    .WithMany(u => u.StudentOfMentorshipRequests)
                    .HasForeignKey(mr => mr.StudentId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<MentorshipFeedback>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Content).IsRequired().HasColumnType("NTEXT");
                entity.HasOne(mf => mf.MentorshipRequest)
                    .WithMany(m => m.MentorshipFeedbacks)
                    .HasForeignKey(mf => mf.MentorshipId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Content).HasColumnType("NTEXT").IsRequired();
                entity.HasOne(s => s.MentorshipRequest)
                    .WithMany(u => u.Sessions)
                    .HasForeignKey(s => s.MentorshipId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Token).IsRequired();
                entity.Property(e => e.Email).IsRequired();
            });

        }
    }
}
