using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniDrive.App.Interfaces;
using MiniDrive.Infrastructure.Contexts;

namespace MiniDrive.App.Implementations
{
    public class FileRepository : IFiles
    {

        private readonly MiniDriveContext _context;

        public FileRepository(MiniDriveContext context)
        {
            _context = context;
        }

        //Function by create a mew file 
        public async Task<Models.File> CreateFile(Models.File file)
        {
            _context.Files.Add(file);
           await _context.SaveChangesAsync();
            return file;   
        }

        //Function by delete a file (Update status of the file)
  public async Task<Models.File> DeleteFileByIdAsync(int id)
        {
            var file = await _context.Files.FindAsync(id);
            if (file == null)
            {
                return null;
            }

            file.Status = "INACTIVE";
            _context.Files.Update(file);
            await _context.SaveChangesAsync();
            return file;
        }
        
public List<Models.File> GetInactiveFilesByUserId(int userId)
{
    return _context.Files.Where(f => f.UserId == userId && f.Status == "INACTIVE").ToList();
}

        //Funtion to get all files 
        public List<Models.File> GetAllFiles()
        {
            return _context.Files.ToList();
        }

        //Funtion to get a file by Id
        public Models.File GetFileById(int id)
        {
            return _context.Files.Find(id);
        }

        //Funtion to get a file by name and extension
        public Models.File GetFileByName(string fileName, string extension)
        {
            return _context.Files.FirstOrDefault(f => f.FileName == fileName && f.FileExtension == extension);
        }

        //Funtion to get all files by folder
        public List<Models.File> GetFilesByFolderId(int folderId)
        {
            return _context.Files.Where(f => f.FolderId == folderId).ToList();
        }

        //Funtion to get all files by user
        public List<Models.File> GetFilesByUserId(int userId)
        {
            return _context.Files.Where(f => f.UserId == userId).ToList();
        }

        //Funtion to get all files by user and folder id
        public List<Models.File> GetFilesByUserIdAndFolderId(int userId, int folderId)
        {
            return _context.Files.Where(f => f.UserId == userId && f.FolderId == folderId).ToList();
        }

        //Funtion to get all files by user and parent folder id
        public List<Models.File> GetFilesByUserIdAndParentFolderId(int userId, int parentFolderId)
        {
            return _context.Files.Where(f => f.UserId == userId && f.FolderId == parentFolderId).ToList();
        }

        //Function to update a file
        public Models.File UpdateFile(Models.File file, int id)
        {
            _context.Files.Update(file);
            _context.SaveChanges();
            return file;
        }
    }
}