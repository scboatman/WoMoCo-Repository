﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoMoCo.Models;
using WoMoCo.Services;
using Microsoft.AspNetCore.Identity;
using WoMoCo.ViewModels.Account;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WoMoCo.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserService _service;
        private UserManager<ApplicationUser> _manager;
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAllUsers());
        }

        //[HttpGet]
        //public IEnumerable<UserViewModel> Get()
        //{
        //    return _service.GetUsers();
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public ApplicationUser Get(string username)
        {
            return _service.GetUserById(username);
        }

        //GET by userName
        [HttpGet("GetUser/")]
        public ApplicationUser GetUser()
        {
            string uid = _manager.GetUserId(User);
            return _service.GetByUsername(uid);
        }
        // move to service

        //GET usersForPullDown
        [HttpGet("GetUsersForPullDown/")]
        public IEnumerable<UserForPullDown> GetUsersForPullDown()
        {
            return _service.GetAllUsersForPullDown();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ApplicationUser user)
        {
            _service.SaveUser(user);
            
            return Ok(user);
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _service.DeleteUser(id);
            return Ok();
        }
        public UsersController(IUserService service, UserManager<ApplicationUser> manager)
        {
            this._manager = manager;
            this._service = service;
        }
    }
}
