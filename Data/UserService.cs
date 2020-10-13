﻿using System;
using System.Collections.Generic;
using System.Linq;
using FileData;
using DNP_Assignment_1.Models;

namespace DNP_Assignment_1.Data
{
    public class UserService : IUserService     
    {
        private static FileContext _fileContext = new FileContext();

    
        public User ValidateUser(string Username, string Password)
        {
            Console.WriteLine(Username);
            Console.WriteLine(_fileContext.Users.Count);
            User first = _fileContext.Users.FirstOrDefault(user => user.UserName.Equals(Username));
            
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(Password))
            {
                throw new Exception("Password incorrect, try again");
            }

            return first;
        }

        public void addUser(User user)
        {
            _fileContext.Users.Add(user);
            _fileContext.SaveChanges();
        }

        public IList<User> getUsers()
        {
            return _fileContext.Users;
        }

        public void editUser()
        {
            _fileContext.SaveChanges();
        }
    }
}