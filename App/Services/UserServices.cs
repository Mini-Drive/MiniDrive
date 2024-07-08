using MiniDrive.App.Implementations;
using MiniDrive.Models;
using MiniDrive.Dtos;
using AutoMapper;

namespace MiniDrive.App.Services
{
    // In this class, we have the logic of the project, restrictions, and permissions for user management
    public class UserServices
    {
        // Instance of our implementation that handles database responsibilities for users
        private readonly UserRepository _userRepository;

        // Instance of our mapper
        private readonly IMapper _mapper;

        // Constructor of the class that implements the mapper and initializes our repository
        public UserServices(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // Function to create a new user
        public User CreateUser(UserDto userDto)
        {
            var user = new User();

            return _userRepository.CreateUser(_mapper.Map(userDto, user));
        }

        // Function to delete a user (Update Status)
        public User DeleteUser(UserDto userDto, int id)
        {
            userDto.Status = "INACTIVE";
            var user = GetUserById(id);
            return _userRepository.DeleteUser(_mapper.Map(userDto, user));
        }

        // Function to get all users
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        // Function to get a unique user in the Users table by Id
        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }   


        // Function to update a user
        public User UpdateUser(UserDto userDto, int id)
        {
            var user = GetUserById(id);
            return _userRepository.UpdateUser(_mapper.Map(userDto, user));
        }


        public User AuthenticateUser(string username, string password)
{
    // Aquí deberías buscar el usuario en la base de datos por el username
    var user = _userRepository.FindByUsername(username);

    if (user != null && VerifyPassword(password, user.Password))
    {
        return user;
    }

    return null;
}

private bool VerifyPassword(string providedPassword, string storedPassword)
{
    
    return providedPassword == storedPassword;
}

    }
}
