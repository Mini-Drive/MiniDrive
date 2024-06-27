using MiniDrive.Dtos;
using MiniDrive.Models;
using Microsoft.AspNetCore.Mvc; 

namespace MiniDrive.App.Interfaces
{
    public interface IUsers
    {
        //function to create a user
       User CreateUser(User user);

        //function to delete a user
        User DeleteUser(User user);

        //function to update a user
        User UpdateUser(User user);

        //function to get a user by id
        User GetUserById(int id);

        //function to get all users

        List<User> GetAllUsers();
        
    }
}