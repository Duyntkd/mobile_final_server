using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MobileFinalProjectServer.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : Controller
    {

        [HttpGet]
        [Route("current")]
        public IActionResult getCurrentTasks(int userId)
        {
            return View();
        }
    }
}