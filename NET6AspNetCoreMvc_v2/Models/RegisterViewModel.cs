using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NET6AspNetCoreMvc_v2.Models
{
    public class RegisterViewModel : LoginViewModel
    {
        [Display(Name = "Şifre:", Prompt = "password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre tekrar zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre tekrar en az 6 karakter olmalıdır!")]
        [MaxLength(16, ErrorMessage = "Şifre tekrar en fazla 16 karakter olabilir!")]
        [Compare(nameof(Password))]
        //Property isimlerini görüyor. -> nameof
        public string RePassword { get; set; }
    }
}
