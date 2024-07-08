using AutoMapper;
using MiniDrive.Dtos;
using MiniDrive.Models;

namespace MiniDrive.App.Utils
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
             CreateMap<LoginDto, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
        
    }
}

           
