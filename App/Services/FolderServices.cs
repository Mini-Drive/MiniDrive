using MiniDrive.App.Implementations;
using MiniDrive.Models;
using MiniDrive.Dtos;

namespace MiniDrive.App.Services
{
    public class FolderServices
    {
        private readonly FolderRepository _folderRepository;

        public FolderServices(FolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        public List<Folder> GetAllFolders()
        {
            return _folderRepository.GetAllFolders();
        }
    }
}