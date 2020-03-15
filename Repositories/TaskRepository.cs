using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MobileFinalProjectServer.DataModels;
using MobileFinalProjectServer.ResponseModels;

namespace MobileFinalProjectServer.Repositories
{
    public class TaskRepository
    {
        private MyDbContext _context;

        public TaskRepository(MyDbContext myDbContext)
        {
            _context = myDbContext;
        }

        public List<TaskInfoForList> getCurrentTasks(int userId)
        {
            List<TaskInfoForList> currentTasks =
                _context.Tasks
                .Where(t => t.AssigneeId == userId && t.Status == "ongoing")
                .Select(t => new TaskInfoForList{id = t.Id, assigner = t.Assigner.Name, endDate = t.EndDate.Value.ToShortDateString(), title = t.Title}).ToList();
            return currentTasks;
        }

        public List<SelfTaskInfoForList> getSelfTasks(int userId)
        {
            List<SelfTaskInfoForList> selfTasks =
                _context.Tasks
                .Where(t => t.AssigneeId == userId && (t.Status == "waiting" || t.Status == "not approve"))
                .Select(t => new SelfTaskInfoForList { id = t.Id, endDate = t.EndDate.Value.ToShortDateString(), title = t.Title, status = t.Status }).ToList();
            return selfTasks;
        }

        internal TaskForDetail getTaskForDetail(int taskId)
        {
            TaskForDetail taskForDetail = _context.Tasks.Where(t => t.Id == taskId).Select(t => new TaskForDetail { id = t.Id, assignerId = t.AssignerId, assignerName = t.Assigner.Name, content = t.Description, title = t.Title, endDate = t.EndDate.Value.ToShortDateString(), startDate = t.StartDate.Value.ToShortDateString(), solutionDescription = t.SolutionDescription }).SingleOrDefault();
            return taskForDetail;
        }

        internal TaskForDetailForManager getTaskForDetailForManager(int taskId)
        {
            TaskForDetailForManager taskForDetail = _context.Tasks.Where(t => t.Id == taskId).Select(t => new TaskForDetailForManager { id = t.Id, assigneeId = t.AssignerId, assigneeName = t.Assignee.Name, content = t.Description, title = t.Title, endDate = t.EndDate.Value.ToShortDateString(), startDate = t.StartDate.Value.ToShortDateString(), solutionDescription = t.SolutionDescription }).SingleOrDefault();
            return taskForDetail;
        }

        public List<GroupTaskInfoForList> getGroupTasksForDisplay(int groupId)
        {
            List<GroupTaskInfoForList> groupTasks =
                _context.Tasks
                .Where(t => t.Assignee.GroupId == groupId && (t.Status != "accepted" && t.Status != "declined" && t.Status != "not approve"))
                .Select(t => new GroupTaskInfoForList { id = t.Id, assignee = t.Assignee.Name, endDate = t.EndDate.Value.ToShortDateString(), title = t.Title, status = t.Status }).ToList();
            return groupTasks;
        }

        internal bool saveTask(int assignerId, int assigneeId, string content, string deadline, string title)
        {
            User assignee = _context.Users.Where(u => u.Id == assigneeId).SingleOrDefault();
            if (assignee == null) return false;
            DateTime deadlineInDb = DateTime.ParseExact(deadline, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            Task newTask = new Task { AssigneeId = assigneeId, AssignerId = assignerId, Description = content, EndDate = deadlineInDb, StartDate = DateTime.Now, Status = "ongoing", Title = title };
            _context.Tasks.Add(newTask);
            _context.SaveChanges();
            return true;
        }

        internal bool updateSelfTask(int taskId, string content, string deadline, string title)
        {
            try
            {
                DateTime deadlineInDb = DateTime.ParseExact(deadline, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                Task task = _context.Tasks.Where(t => t.Id == taskId).FirstOrDefault();
                task.Description = content;
                task.EndDate = deadlineInDb;
                task.Title = title;
                _context.Tasks.Update(task);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }          
            return true;
        }

        internal bool removeSelfTask(int taskId)
        {
            try
            {                
                Task task = _context.Tasks.Where(t => t.Id == taskId).FirstOrDefault();                
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        internal void changeTaskStatus(int taskId, string status)
        {
            Task task = _context.Tasks.Where(t => t.Id == taskId).SingleOrDefault();
            task.Status = status;
            _context.Update(task);
            _context.SaveChanges();
        }

        
    }
}
