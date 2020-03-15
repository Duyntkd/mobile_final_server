using System;
namespace MobileFinalProjectServer.Models
{
    public class AssignTaskObject
    {       
        public int assignerId { get; set; }
        public int assigneeId { get; set; }
        public string content { get; set; }
        public string deadline { get; set; }
        public string title { get; set; }

        public AssignTaskObject()
        {
        }
    }
}
