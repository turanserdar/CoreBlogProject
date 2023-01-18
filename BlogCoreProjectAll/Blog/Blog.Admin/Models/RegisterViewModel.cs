using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Admin.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(30)]
        public string Firstname { get; set; }


        [Required(ErrorMessage = "Bu alan zorunlu!")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girilebilir.", MinimumLength = 2)]
        public string Lastname { get; set; }


        [Required(ErrorMessage = "Bu alan zorunlu!")]
        [EmailAddress(ErrorMessage = "ornek@mail.com şeklinde giriş yapınız.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Bu alan zorunlu!")]
        [StringLength(12, ErrorMessage = "Şifrenizi en az 4, en fazla 12 karakter girilebilir.", MinimumLength = 4)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Bu alan zorunlu!")]
        [StringLength(12, ErrorMessage = "Şifrenizi en az 4, en fazla 12 karakter girilebilir.", MinimumLength = 4)]
        [Compare(nameof(Password), ErrorMessage = "Şifreler uyuşmuyor!")]
        public string PasswordConfirm { get; set; }

    }
}
