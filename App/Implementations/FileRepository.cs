using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniDrive.App.Interfaces;

namespace MiniDrive.App.Implementations
{
    public class FileRepository : IFiles
    {
        public Models.File CreateFile(Models.File file)
        {
            throw new NotImplementedException();
        }

        public Models.File DeleteFile(Models.File file, int id)
        {
            throw new NotImplementedException();
        }

        public List<Models.File> GetAllFiles()
        {
            throw new NotImplementedException();
        }

        public Models.File GetFileById(int id)
        {
            throw new NotImplementedException();
        }

        public Models.File GetFileByName(string fileName)
        {
            throw new NotImplementedException();
        }

        public List<Models.File> GetFilesByFolderId(int folderId)
        {
            throw new NotImplementedException();
        }

        public List<Models.File> GetFilesByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public List<Models.File> GetFilesByUserIdAndFolderId(int userId, int folderId)
        {
            throw new NotImplementedException();
        }

        public List<Models.File> GetFilesByUserIdAndParentFolderId(int userId, int parentFolderId)
        {
            throw new NotImplementedException();
        }

        public Models.File UpdateFile(Models.File file, int id)
        {
            throw new NotImplementedException();
        }
    }
}