using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MiniDrive.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Age { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateOnly CreateAt {get;set;}

        [Required]
        public string Status {get;set;}

        [JsonIgnore]
        public List<Folder>? Folders { get; set; }

        [JsonIgnore]
        public List<File>? Files { get; set; }

    }
}