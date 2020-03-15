using System;
namespace MobileFinalProjectServer.ResponseModels
{
    public class TaskInfoForList
    {
        public int id { get; set; }
        public string title { get; set; }
        public String endDate { get; set; }
        public string assigner { get; set; }


        public TaskInfoForList()
        {
        }
    }
}
