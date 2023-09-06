using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public UserController(UserService dataFromService){
                _data = dataFromService;
            }
        //Add a user
        [HttpPost("AddUsers")]
        public bool AddUser(CreateAccountDTO UserToAdd){
            return _data.AddUser(UserToAdd);
           
        }
            //Do some logic to see if the user already exist
            //if the user exist, we do nothing
            //if user does not exisit, lead me to create an account else throw error
    }

    //Login
    //Update user account
    //Delete User Account






}