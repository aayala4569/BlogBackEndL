using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEndL.Models;
using BlogBackEndL.Models.DTO;
using BlogBackEndL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BlogBackEndL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase

    {
        //create a variable with a type of service
        private readonly UserService _data;

        //Create a constructor
        public UserController(UserService dataFromService)
        {
            _data = dataFromService;
        }
        //Add a user
        [HttpPost("AddUsers")]

        public bool AddUser(CreateAccountDTO UserToAdd)
        {
            return _data.AddUser(UserToAdd);

        }
        //Do some logic to see if the user already exist
        //if the user exist, we do nothing
        //if user does not exisit, lead me to create an account else throw error


        //This is our get all users
        [HttpGet("GetAllUsers")]

        //Now we need a method to get all users

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _data.GetAllUsers();
        }

        //Login input
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO User)
        {
            return _data.Login(User);
        }



        //Delete User Account
        [HttpPost("DeleteUser/{userToDelete}")]

        public bool DeleteUser(string userToDelete)
        {
            return _data.DeleteUser(userToDelete);
        }


        //Update user account
        [HttpPost("UpdateUser")]

        public bool UpdateUser(int id, string username)
        {
            return _data.UpdateUsername(id, username);
        }
    }

}