using System.ComponentModel.DataAnnotations;

namespace NET6AspNetCoreMvc_v2.Models
{
    //Login formundan datayı almak için gerekli olan modelimiz.
    public class LoginViewModel
    {
        [Display(Name = "Kullnıcı Adı:", Prompt = "johndoe")]
        [Required(ErrorMessage = "Kullanıcı adı zorunludur!")]
        [StringLength(30, ErrorMessage = "Kullanıcı adı en fazla 30 karakter olabilir!")]
        public string Username { get; set; }

        [Display(Name = "Şifre:", Prompt = "password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır!")]
        [MaxLength(16, ErrorMessage = "Şifre en fazla 16 karakter olabilir!")]
        public string Password { get; set; }
    }
}
