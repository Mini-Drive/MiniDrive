namespace MiniDrive.Models
{
    public class File
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? FileExtension { get; set; }
        public int? FolderId { get; set; }
        public Folder? Folder { get; set; }
        public DateOnly? CreateAt { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public byte[]? Content { get; set; }
        public byte[]? IV { get; set; }
        public string? EncryptionKey { get; set; }
        public string? Status { get; set; }
    }
}