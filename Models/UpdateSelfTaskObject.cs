using System;
namespace MobileFinalProjectServer.Models
{
    

    public class UpdateSelfTaskObject
    {
        public int taskId { get; set; }
        public string content { get; set; }
        public string deadline { get; set; }
        public string title { get; set; }
        public UpdateSelfTaskObject()
        {
        }
    }
}
