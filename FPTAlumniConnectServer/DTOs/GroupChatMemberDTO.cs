namespace FPTAlumniConnectServer.DTOs
{
    public class GroupChatMemberDTO
    {
        public int GroupChatId { get; set; }
        public int UserId { get; set; }
        public int? AddedByUserId { get; set; }
    }
}
