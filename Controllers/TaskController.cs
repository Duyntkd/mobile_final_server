using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MobileFinalProjectServer.DataModels;
using MobileFinalProjectServer.Models;
using MobileFinalProjectServer.Repositories;
using MobileFinalProjectServer.ResponseModels;

namespace MobileFinalProjectServer.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : Controller
    {
        private TaskRepository _taskRepository;

        public TaskController (TaskRepository taskRepository)
        {
            this._taskRepository = taskRepository;
        }

        [HttpGet]
        [Route("current")]
        public IActionResult getCurrentTasks(int userId)
        {
            List<TaskInfoForList> currentTasks = _taskRepository.getCurrentTasks(userId);
            return Json(currentTasks);
        }

        [HttpGet]
        [Route("self")]
        public IActionResult getSelfTasks(int userId)
        {
            List<SelfTaskInfoForList> selfTasks = _taskRepository.getSelfTasks(userId);
            return Json(selfTasks);
        }

        [HttpGet]
        [Route("self/detail")]
        public IActionResult getSelfTask(int taskId)
        {
            TaskForDetail taskForDetail = _taskRepository.getTaskForDetail(taskId);
            return Json(taskForDetail);
        }

        [HttpPut]
        [Route("self")]
        public IActionResult updateSelfTask(UpdateSelfTaskObject input)
        {
            if(_taskRepository.updateSelfTask(input.taskId, input.content, input.deadline, input.title))
            {
                return Json(new { status = "success" });
            }
            return  Json(new { status = "failed" }); ;
        }

        [HttpPut]
        [Route("self/delete")]
        public IActionResult removeSelfTask(UpdateSelfTaskObject input)
        {
            if (_taskRepository.removeSelfTask(input.taskId))
            {
                return Json(new { status = "success" });
            }
            return Json(new { status = "failed" }); ;
        }

        [HttpGet]
        [Route("group")]
        public IActionResult getGroupTasks(int groupId)
        {
            List<GroupTaskInfoForList> groupTasks = _taskRepository.getGroupTasksForDisplay(groupId);
            return Json(groupTasks);
        }

        [HttpGet]
        [Route("detail")]
        public IActionResult getTaskDetail(int taskId)
        {
            TaskForDetail taskForDetail = _taskRepository.getTaskForDetail(taskId);
            return Json(taskForDetail);
        }

        [HttpGet]
        [Route("detail/manager")]
        public IActionResult getTaskDetailForManager(int taskId)
        {
            TaskForDetailForManager taskForDetail = _taskRepository.getTaskForDetailForManager(taskId);
            return Json(taskForDetail);
        }

        [HttpGet]
        [Route("confirm")]
        public IActionResult conFirmTaskDone(int taskId, string status)
        {
            _taskRepository.changeTaskStatus(taskId, status);
            return Json(new {Update = "Success"});            
        }

        [HttpPost]
        [Route("assign")]
        public IActionResult assignTask(AssignTaskObject input) 
        {
            bool result = _taskRepository.saveTask(input.assignerId, input.assigneeId, input.content, input.deadline, input.title);
            if(!result) return Json(new { status = "failed" });
            return Json(new { status = "success" });
        }
    }
}