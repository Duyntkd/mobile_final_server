using System;
namespace MobileFinalProjectServer.ResponseModels
{
    public class TaskForDetail
    {
        public int id { get; set; }

        public String title { get; set; }
        public String content { get; set; }
        public String solutionDescription { get; set; }
        public int assignerId { get; set; }
        public String assignerName { get; set; }
        public String startDate { get; set; }
        public String endDate { get; set; }

        public TaskForDetail()
        {

        }
    }
}
