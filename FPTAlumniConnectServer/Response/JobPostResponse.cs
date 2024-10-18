﻿namespace FPTAlumniConnectServer.Response
{
    public class JobPostResponse
    {
        public int JobPostID { get; set; }
        public string JobTitle { get; set; }
        public string Salary { get; set; }
        public string Location { get; set; }
        public string Experience { get; set; }
        public DateTime Deadline { get; set; }
        public string JobDescription { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserID { get; set; }
    }
}
