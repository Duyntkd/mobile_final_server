using System;
namespace MobileFinalProjectServer.DataModels
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<double> Score { get; set; } = 0;
        public string Feedback { get; set; }
        public Nullable<DateTime> StartDate { get; set; } = DateTime.Today;
        public Nullable<DateTime> EndDate { get; set; } = DateTime.Today;
        public int AssignerId { get; set; }
        public int AssigneeId { get; set; }
        public Nullable<Int32> SolutionSource { get; set; } = 0;
        public string ConfirmReport { get; set; }
        public string Status { get; set; }
        public string SolutionDescription { get; set; }

        public User Assigner { get; set; }
        public User Assignee { get; set; }


        public Task()
        {

        }
    }
}
