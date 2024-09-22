using Microsoft.AspNetCore.Mvc;

namespace FPTAlumniConnectServer.Entities
{
    public class MessageGroupChat
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public virtual GroupChatMember GroupChatMember { get; set; }
    }
}
