namespace FPTAlumniConnectServer.Response
{
    public class GroupChatResponse
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } // Assuming User has a name
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<GroupChatMemberResponse> Members { get; set; }
    }
}
