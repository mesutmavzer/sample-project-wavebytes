using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nutritions.Api.Contract;
using Nutritions.Api.DataModels;
using Nutritions.Api.DB;
using Nutritions.Api.Services;

namespace Nutritions.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public NutritionsContext NutritionsContext { get; }
        public UserService UserService { get; }

        public UsersController(NutritionsContext context, UserService userService)
        {
            this.NutritionsContext = context;
            this.UserService = userService;
        }


        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            var oneUser= UserService.GetUserById(id);
            return Ok((UserResponse)oneUser);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var allUsers = UserService.GetAllUsers().Select(user => (UserResponse)user);
            //throw new ApiException(System.Net.HttpStatusCode.BadRequest, "ERR001", "Email is reeds in gebruik");
            return Ok(allUsers);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            UserService.DeleteUser(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserRequest user)
        {
            var newUser = UserService.CreateUser((User)user, user.Password);
            return Ok((UserResponse)(newUser));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, [FromBody] UserRequest user)
        {
            var updatedUser = UserService.UpdateUser(id, (User)user);
            return Ok((UserResponse)updatedUser);
        }


    }
}