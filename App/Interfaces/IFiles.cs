
namespace MiniDrive.App.Interfaces
{
    public interface IFiles
    {
        //function to get all files
        List<Models.File> GetAllFiles();

        //function to get a file by id
        Models.File GetFileById(int id);

        //function to get a file by name and extensions
        Models.File GetFileByName(string fileName, string extension);

        //function to get all files by folder id
        List<Models.File> GetFilesByFolderId(int folderId);

        //function to create a file
        Task<Models.File> CreateFile(Models.File file);

        //function to delete a file
        Task<Models.File> DeleteFileByIdAsync(int id);

        //function to update a file
        Models.File UpdateFile(Models.File file, int id);

        //function to get all files by user id
        List<Models.File> GetFilesByUserId(int userId);

        //function to get all files by user id and folder id
        List<Models.File> GetFilesByUserIdAndFolderId(int userId, int folderId);

        //function to get all files by user id and parent folder id
        List<Models.File> GetFilesByUserIdAndParentFolderId(int userId, int parentFolderId);
    }
}