using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaProject.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Прізвище")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [StringLength(16, ErrorMessage = "{0} повинен мати мінімум {2} и максимум {1} символів.", MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        [Display(Name = "Підтверждення паролю")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
