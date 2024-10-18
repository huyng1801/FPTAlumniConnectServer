namespace FPTAlumniConnectServer.Response
{
    public class GroupChatMemberResponse
    {
        public int Id { get; set; }
        public int GroupChatId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsLeaved { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? AddedByUserId { get; set; }
        public string AddedByUserName { get; set; }
    }
}
