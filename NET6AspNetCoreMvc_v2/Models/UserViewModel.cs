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

    public class CreateUserViewModel
    {
        public string? NameSurname { get; set; }

        [Display(Name = "Kullnıcı Adı:", Prompt = "johndoe")]
        [Required(ErrorMessage = "Kullanıcı adı zorunludur!")]
        [StringLength(30, ErrorMessage = "Kullanıcı adı en fazla 30 karakter olabilir!")]
        public string UserName { get; set; }

        [Display(Name = "Şifre:", Prompt = "password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır!")]
        [MaxLength(16, ErrorMessage = "Şifre en fazla 16 karakter olabilir!")]
        public string Password { get; set; }

        [Display(Name = "Şifre:", Prompt = "password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre tekrar zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre tekrar en az 6 karakter olmalıdır!")]
        [MaxLength(16, ErrorMessage = "Şifre tekrar en fazla 16 karakter olabilir!")]
        [Compare(nameof(Password))]
        //Property isimlerini görüyor. -> nameof
        public string RePassword { get; set; }

        public string Role { get; set; } = "User";
        public bool Locked { get; set; }

      
    }
}
