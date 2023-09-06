using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEndL.Models;
using BlogBackEndL.Models.DTO;
using BlogBackEndL.Services.Context;
using System.Security.Cryptography;

namespace BlogBackEndL.Services
{
    public class UserService
    {
        //Create a variable
        private readonly DataContext _context;
        //create a constructor
        public UserService(DataContext context)
        {
            _context = context;
        }

        //Helper function- Does user exist(string username)

        public bool DoesUserExist(string? username)
        {
            //Checks the table to see if the username exist
            //If one item matches our condition, that item will be returned
            //if no item matches the condition it will return null
            //if mutiple items match the condition, will return an error

            // UserModel foundUser = _context.UserInfor.SingleOrDefault(user => user.Username == username)

            // if(foundUser == null){
            //     //the user does not exist
            // }
            // else{
            //     //the user does not exist
            // }

            return _context.UserInfor.SingleOrDefault(user => user.Username == username) != null;
        }

        public bool AddUser(CreateAccountDTO UserToAdd)
        {

            bool result = false;
            //if the user already exist
            if (!DoesUserExist(UserToAdd.Username))
            {
                //If true, we need to create a new instance of our UserModel
                //Every time you want to create a new instance or object of a class, start with new

                UserModel newUser = new UserModel();

                var newHashedPassword = HashPassword(UserToAdd.Password);

                newUser.Id = UserToAdd.Id;

                newUser.Username = UserToAdd.Username;

                newUser.Salt = newHashedPassword.Salt;
                newUser.Hash = newHashedPassword.Hash;

                _context.Add(newUser);
                _context.SaveChanges();
            }
            return result;
            //if they do not exist we then need to add account
            //else throw a false
        }







        public PasswordDTO HashPassword(string password)
        {

            //logic goes here
            //Create a password DTO, this is what we are going to return.
            //We need to create an new instance of our password DTO

            PasswordDTO newHashedPassword = new PasswordDTO();
            //Salt byte size of our Saltbytes which is 64
            byte[] SaltBytes = new Byte[64];

            //RNGCryptoServiceProvider creates random numbers

            var provider = new RNGCryptoServiceProvider();
            //now we are going to exclude all the zeros
            provider.GetNonZeroBytes(SaltBytes);
            //This is going to grab our 64 byte string cryp and encrypt for us
            var Salt = Convert.ToBase64String(SaltBytes);
            //We will use the below to create the has. First argument is the password, bytes, iterations
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltBytes, 10000);
            //Now we create our hash
            var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            //return newHashed
            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = Hash;

            return newHashedPassword;

        }
        public bool VerifyUserPassword(string? Password, string? StoredHash, string? StoredSalt)
        {
            var SaltBytes = Convert.FromBase64String(StoredSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            return newHash == StoredHash;
        }
    }
}