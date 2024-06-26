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
       IActionResult UpdateUser(UserDto userDto);
        
    }
}