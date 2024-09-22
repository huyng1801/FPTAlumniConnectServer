using System.Collections.ObjectModel;

namespace FPTAlumniConnectServer.Entities
{
    public class GroupChatMember
    {
        public int Id { get; set; }
        public int GroupChatId { get; set; }
        public int UserId { get; set; }
        public bool IsLeaved { get; set; }
        public bool IsBlock {  get; set; }
        public DateTime CreatedAt { get; set; }
        public int? AddedByUserId { get; set; } 
        public virtual GroupChat GroupChat { get; set; }
        public virtual User User { get; set; }
        public virtual User AddedByUser { get; set; }
        public virtual ICollection<MessageGroupChat> MessageGroupChats { get; set; }
    }
}