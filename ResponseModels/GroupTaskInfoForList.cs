using System;
namespace MobileFinalProjectServer.ResponseModels
{
    public class GroupTaskInfoForList
    {
        public int id { get; set; }
        public String title { get; set; }
        public String endDate { get; set; }
        public String assignee { get; set; }
        public String status { get; set; }

        public GroupTaskInfoForList()
        {
        }
    }
}
