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

        public Folder DeleteFolder(Folder folder)
        {
            _context.Folders.Update(folder);
            _context.SaveChanges();
            return folder;
        }

        public List<Folder> GetAllFolders()
        {
            return _context.Folders.ToList();
        }

        public Folder GetFolderByFolderName(string folderName)
        {
            return _context.Folders.FirstOrDefault(u => u.FolderName == folderName);
        }

        public Folder GetFolderById(int id)
        {
            return _context.Folders.FirstOrDefault(u => u.Id == id);
        }

        public List<Folder> GetFoldersByParentFolderID(int parentFolderID)
        {
            return _context.Folders.Where(u => u.ParentFolderID == parentFolderID).ToList();
        }

        public List<Folder> GetFoldersByUserId(int userId)
        {
            return _context.Folders.Where(u => u.UserId == userId).ToList();
        }

        public Folder UpdateFolder(Folder folder)
        {
            _context.Folders.Update(folder);
            _context.SaveChanges();
            return folder;
        }
    }
}