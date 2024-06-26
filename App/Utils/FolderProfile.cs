using AutoMapper;
using MiniDrive.Dtos;
using MiniDrive.Models;

namespace MiniDrive.App.Utils
{
    public class FolderProfile : Profile
    {
        public FolderProfile()
        {
            CreateMap<FolderDto, Folder>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Folder, FolderDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
        
    }
}