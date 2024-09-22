﻿namespace FPTAlumniConnectServer.Entities
{
    public class PostReport
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
