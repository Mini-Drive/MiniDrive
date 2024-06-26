using System.Text.Json.Serialization;

namespace MiniDrive.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public string? FolderName { get; set; }
        public int? ParentFolderID { get; set; }
        public Folder? ParentFolder { get; set; }
        public DateOnly? CreateAt { get; set; }
        public int? UserId { get; set; }
        //public User? User { get; set; }
        public string? Status { get; set; }

        [JsonIgnore]
        public List<File>? Files { get; set; }
        [JsonIgnore]
        public List<Folder>? Folders { get; set; }
    }
}