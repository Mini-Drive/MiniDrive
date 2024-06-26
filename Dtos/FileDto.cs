namespace MiniDrive.Dtos
{
    public class FileDto
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? FileExtension { get; set; }
        public int? FolderId { get; set; }
        public DateOnly? CreateAt { get; set; }
        public int? UserId { get; set; }
        public string? Status { get; set; }
    }
}