using System.Collections.Generic;
using DNP_Assignment_1.Models;

namespace DNP_Assignment_1.Data
{
    public interface IUserService
    {
        User ValidateUser(string Username, string Password);
        void addUser(User user);
        
        IList<User> getUsers();

        void editUser();
    }
}