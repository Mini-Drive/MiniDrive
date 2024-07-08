using MiniDrive.App.Interfaces;
using MiniDrive.Models;
using MiniDrive.Dtos;
using AutoMapper;
using MiniDrive.Infrastructure.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace MiniDrive.App.Implementations
{
    public class UserRepository : IUsers
    {
        private readonly MiniDriveContext _context;

        private readonly IMapper _mapper;

        public UserRepository(MiniDriveContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Function to get all users
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        //Function to get a user by id

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        //Function to create a new user
        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        //Function to delete a user
        public User DeleteUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        //Function to update user
        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public User FindByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username);
        }
    }
}


