using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileFinalProjectServer.DataModels;
using MobileFinalProjectServer.Models;
using MobileFinalProjectServer.Repositories;

namespace MobileFinalProjectServer.Controllers
{
    [Route("api/authen")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private UserRepository _userRepository;

        public AuthenticationController (UserRepository userRepository)
        {
            _userRepository = userRepository;
        }     

        [HttpGet]
        [Route("try")]
        public async Task<IActionResult> tryRequest()
        {            
            return Json("aaaaa");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> checkLogin (LoginObject loginObject)
        {           
            User user = _userRepository.checkLogin(loginObject.Username, loginObject.Password);
            return Json( new {User = user });        
        }

        




    }
}