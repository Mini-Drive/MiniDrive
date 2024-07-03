using MiniDrive.App.Implementations;
using MiniDrive.Models;
using MiniDrive.Dtos;
using AutoMapper;

namespace MiniDrive.App.Services
{   
    //In this class we have the logic of proyect, restrictions and permissions
    public class FolderServices
    {
        //Instance of our implementation that do anything about responsabilities of the database
        private readonly FolderRepository _folderRepository;

        //Instance of our mapper
        private readonly IMapper _mapper;


        //Constructor of the class that implements the mapper, and initialize our repository
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

        public Folder DeleteFolder(int id)
        {
            var folder = GetFolderById(id);
            folder.Status = "INACTIVE";
            return _folderRepository.DeleteFolder(folder);
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

        //Function to update a folder in the Folders table
        public Folder UpdateFolder(FolderDto folderDto, int id)
        {
            var folder = GetFolderById(id);
            return _folderRepository.UpdateFolder(_mapper.Map(folderDto, folder));
        }
    }
}