using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.BackOffice.Models.AuthView
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email boş geçilemez.")]
        [EmailAddress(ErrorMessage = "Email formatı düzgün değil.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        [MinLength(8, ErrorMessage = "Şifre uzunluğu 8 karakterden kısa olamaz.")]
        public string Password { get; set; }
    }
}
