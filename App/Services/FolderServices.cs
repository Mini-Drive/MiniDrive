using MiniDrive.App.Implementations;
using MiniDrive.Models;
using MiniDrive.Dtos;
using AutoMapper;

namespace MiniDrive.App.Services
{
    public class FolderServices
    {
        private readonly FolderRepository _folderRepository;
        private readonly IMapper _mapper;

        public FolderServices(FolderRepository folderRepository, IMapper mapper)
        {
            _folderRepository = folderRepository;
            _mapper = mapper;
        }

        //Function to Create a new folder
        public Folder CreateFolder(FolderDto folderDto)
        {
            var folder = new Folder();
            
            return _folderRepository.CreateFolder(_mapper.Map(folderDto, folder));
        }

        //Function to Delete a folder (Update Status)

        public Folder DeleteFolder(FolderDto folderDto)
        {
            folderDto.Status = "INACTIVE";
            var folder = new Folder();
            return _folderRepository.DeleteFolder(_mapper.Map(folderDto, folder));
        }

        //Funtion to get all folders
        public List<Folder> GetAllFolders()
        {
            return _folderRepository.GetAllFolders();
        }
        
        //Function to get the unique folders in the Folders table by FolderName
        public Folder GetFolderByFolderName(string folderName)
        {
            return _folderRepository.GetFolderByFolderName(folderName);
        }

        //Function to get the unique folders in the Folders table by Id
        public Folder GetFolderById(int id)
        {
            return _folderRepository.GetFolderById(id);
        }

        //Function to get the list of folders in the Folders table by ParentFolderID
        public List<Folder> GetFoldersByParentFolderID(int parentFolderID)
        {
            return _folderRepository.GetFoldersByParentFolderID(parentFolderID);
        }

        //Function to get the list of folders in the Folders table by UserId
        public List<Folder> GetFoldersByUserId(int userId)
        {
            return _folderRepository.GetFoldersByUserId(userId);
        }


    }
}