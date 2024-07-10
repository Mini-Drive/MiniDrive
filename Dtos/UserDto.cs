
namespace MiniDrive.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Age { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }

        public DateOnly? CreateAt { get; set; }

        public string? Status { get; set; }

    }
}