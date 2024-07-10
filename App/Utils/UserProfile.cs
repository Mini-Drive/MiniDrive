using AutoMapper;
using MiniDrive.Dtos;
using MiniDrive.Models;

namespace MiniDrive.App.Utils
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
        
    }
}