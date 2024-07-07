using MiniDrive.Dtos;
using MiniDrive.Models;
namespace MiniDrive.App.Interfaces
{
    public interface IFolders
    {
        //Function to get the all folders in the Folders table
        List<Folder> GetAllFolders();

        //Function to get the unique folders in the Folders table by Id
        Folder GetFolderById(int id);

        //Function to get the unique folders in the Folders table by FolderName
        Folder GetFolderByFolderName(string folderName);

        //Function to get the list of folders in the Folders table by ParentFolderID
        List<Folder> GetFoldersByParentFolderID(int parentFolderID);

        //Function to get the list of folders in the Folders table by UserId
        List<Folder> GetFoldersByUserId(int userId);

        //Function to get the index folder (parentFolderID = null) by user
        Folder GetIndexFolderByUserId(int userId);

        //Function to create a folder in the Folders table
        Folder CreateFolder(Folder folder);

        //Function to update a folder in the Folders table
        Folder UpdateFolder(Folder folder);

        //Function to delete a folder in the Folders table
        Folder DeleteFolder(Folder folder);
    }
}