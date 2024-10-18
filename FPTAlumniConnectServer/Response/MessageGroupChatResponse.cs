namespace FPTAlumniConnectServer.Response
{
    public class MessageGroupChatResponse
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string MemberUserName { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
