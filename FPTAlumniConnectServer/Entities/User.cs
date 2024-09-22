namespace FPTAlumniConnectServer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public RoleEnum Role { get; set; }
        public string? EducationHistory { get; set; }
        public string? Major { get; set; }
        public bool IsMentor { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual ICollection<JobPost> JobPosts { get; set; }
        public virtual ICollection<GroupChat> GroupChats { get; set; }
        public virtual ICollection<GroupChatMember> GroupChatMembers { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; }
        public virtual ICollection<UserJoinEvent> UserJoinEvents { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<PostReport> PostReports { get; set; }
        public virtual ICollection<Notification> SentNotifications { get; set; }
        public virtual ICollection<Notification> ReceivedNotifications { get; set; }
        public virtual ICollection<NotificationSetting> NotificationSettings { get; set; }
        public virtual ICollection<PrivacySetting> PrivacySettings { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<GroupChatMember> AddedGroupChatMembers { get; set; }
        public virtual ICollection<MentorshipRequest> MentorOfMentorshipRequests { get; set; }
        public virtual ICollection<MentorshipRequest> StudentOfMentorshipRequests { get; set; }
    }
}
