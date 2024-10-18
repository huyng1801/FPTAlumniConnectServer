﻿namespace FPTAlumniConnectServer.Response
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; } // Optional: Include user's name for better display
    }
}
