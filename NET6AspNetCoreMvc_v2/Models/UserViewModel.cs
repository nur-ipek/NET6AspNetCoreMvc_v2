using System.ComponentModel.DataAnnotations;

namespace NET6AspNetCoreMvc_v2.Models
{
    public class UserViewModel
    {

        public Guid Id { get; set; }

        public string? NameSurname { get; set; }

        public string UserName { get; set; }

        public bool Locked { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string ProfileImageFileName { get; set; } = "no-image.jpg";

        public string Role { get; set; } = "User";
    }
}
