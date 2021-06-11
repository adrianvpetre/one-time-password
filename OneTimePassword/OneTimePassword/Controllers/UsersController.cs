using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneTimePassword.Models.Entities;
using OneTimePassword.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneTimePassword.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        //our "database" of users
        public static List<User> UserList = new List<User>()
        {
            new User(){Id = 1},
            new User(){Id = 2},
            new User(){Id = 3}
        };

        private readonly IPasswordGenerator PasswordGenerator;


        public UsersController(IPasswordGenerator passwordGenerator)
        {
            this.PasswordGenerator = passwordGenerator;
        }


        [HttpGet("")]
        public IActionResult GetUsers()
        {
            return Ok(UserList);
        }

        [HttpGet("{id}/password")]
        public IActionResult GetPasswordForUser(int id)
        {
            var user = UserList.FirstOrDefault(f => f.Id == id);
            if (user == null)
                return NotFound();

            if (user.Password != null && this.PasswordGenerator.CheckPassword(user.Password))
            {
                return Ok(user.Password);
            }
            else
            {
                user.Password = this.PasswordGenerator.GeneratePassword();
                return Ok(user.Password);
            }
        }

    }
}
