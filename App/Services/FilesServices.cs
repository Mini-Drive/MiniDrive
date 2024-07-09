using AutoMapper;
using MiniDrive.App.Implementations;
using MiniDrive.Dtos;
namespace MiniDrive.App.Services
{
    public class FilesServices
    {
        private readonly FileRepository _implement;
        private readonly IMapper _mapper;

        public FilesServices(FileRepository implement, IMapper mapper){
            _implement = implement;
            _mapper = mapper;
        }

        //Function for create a new file
        public async Task<Models.File> CreateFile(FileDto filedto){
            var file = new Models.File();
            _mapper.Map(filedto, file);
            return await _implement.CreateFile(file);
        }

        //Function for delete a file

public async Task<Models.File> DeleteFileByIdAsync(int id)
{
    return await _implement.DeleteFileByIdAsync(id);
}
        //Function to get all files
        public List<Models.File> GetAllFiles(){
            return _implement.GetAllFiles();
        }

        //Function to get a file by id
        public Models.File GetFileById(int id){
            return _implement.GetFileById(id);
        }

        //Function to get a file by name and extension
        public Models.File GetFileByName(string fileName, string extension){
            return _implement.GetFileByName(fileName, extension);
        }

        //Function to get all files by folder id
        public List<Models.File> GetFilesByFolderId(int folderId){
            return _implement.GetFilesByFolderId(folderId);
        }

        //Function to get all files by user id
        public List<Models.File> GetFilesByUserId(int userId){
            return _implement.GetFilesByUserId(userId);
        }

        //Function to get all files by user id and folder id
        public List<Models.File> GetFilesByUserIdAndFolderId(int userId, int folderId){
            return _implement.GetFilesByUserIdAndFolderId(userId, folderId);
        }

        //Function to update a file
        public Models.File UpdateFile(FileDto filedto, int id){
            var file = GetFileById(id);
            filedto.Content = file.Content;
            _mapper.Map(filedto, file);
            return _implement.UpdateFile(file, id);
        }
    }
}

