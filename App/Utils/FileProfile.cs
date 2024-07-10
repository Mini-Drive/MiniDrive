using AutoMapper;
using MiniDrive.Dtos;


namespace MiniDrive.App.Utils
{

    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<FileDto, Models.File>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }

    }

}