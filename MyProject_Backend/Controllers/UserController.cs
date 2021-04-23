using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject_Backend.InterfaceService;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject_Backend.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        [Route("user")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {
            var results = await _user.GetAllUserAsync();
            return Ok(results);
        }
    }
}
