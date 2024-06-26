using MiniDrive.App.Interfaces;
using MiniDrive.Models;
using MiniDrive.Infrastructure.Contexts;

namespace MiniDrive.App.Implementations
{
    public class FolderRepository : IFolders
    {
        private readonly MiniDriveContext _context;

        public FolderRepository(MiniDriveContext context)
        {
            _context = context;
        }

        //Funtion to create a new folder
        public Folder CreateFolder(Folder folder)
        {
            _context.Folders.Add(folder);
            _context.SaveChanges();
            return folder;
        }

        //Function to delete a folder (Update Status of folder)
        public Folder DeleteFolder(Folder folder)
        {
            _context.Folders.Update(folder);
            _context.SaveChanges();
            return folder;
        }

        //Function to get the list of folders in the Folders tabl
        public List<Folder> GetAllFolders()
        {
            return _context.Folders.ToList();
        }


        //Function to get the unique folders in the Folders table by FolderName
        public Folder GetFolderByFolderName(string folderName)
        {
            return _context.Folders.FirstOrDefault(u => u.FolderName == folderName);
        }

        //Function to get the unique folders in the Folders table by Id
        public Folder GetFolderById(int id)
        {
            return _context.Folders.FirstOrDefault(u => u.Id == id);
        }


        //Function to get the list of folders in the Folders table by ParentFolderID
        public List<Folder> GetFoldersByParentFolderID(int parentFolderID)
        {
            return _context.Folders.Where(u => u.ParentFolderID == parentFolderID).ToList();
        }

        //Function to get the list of folders in the Folders table by UserId
        public List<Folder> GetFoldersByUserId(int userId)
        {
            return _context.Folders.Where(u => u.UserId == userId).ToList();
        }


        //Function to update a folder in the Folders table
        public Folder UpdateFolder(Folder folder)
        {
            _context.Folders.Update(folder);
            _context.SaveChanges();
            return folder;
        }
    }
}