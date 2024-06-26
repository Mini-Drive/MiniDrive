using AutoMapper;
using MiniDrive.Dtos;
using MiniDrive.Models;

namespace MiniDrive.Utils
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
        
    }
}