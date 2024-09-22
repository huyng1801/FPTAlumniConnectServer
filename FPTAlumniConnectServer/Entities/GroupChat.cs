using System.Collections.ObjectModel;

namespace FPTAlumniConnectServer.Entities
{
    public partial class GroupChat
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual User User { get; set; }
        public virtual Collection<GroupChatMember> GroupChatMembers { get; set; }
    }
}
