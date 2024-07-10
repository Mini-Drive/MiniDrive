namespace MiniDrive.Dtos
{
    public class FolderDto
    {
        public int Id { get; set; }
        public string? FolderName { get; set; }
        public int? ParentFolderID { get; set; }
        public DateOnly? CreateAt { get; set; }
        public int? UserId { get; set; }
        public string? Status { get; set; }
    }
}