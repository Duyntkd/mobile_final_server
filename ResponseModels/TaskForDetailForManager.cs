using System;
namespace MobileFinalProjectServer.ResponseModels
{
    public class TaskForDetailForManager
    {       
        public int id { get; set; }
        public String title { get; set; }
        public String content { get; set; }
        public String solutionDescription { get; set; }
        public int assigneeId { get; set; }
        public String assigneeName { get; set; }
        public String startDate { get; set; }
        public String endDate { get; set; }

        public TaskForDetailForManager()
        {

        }
    }
}
