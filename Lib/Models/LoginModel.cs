﻿using System.ComponentModel.DataAnnotations;

namespace Lib.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не вказаний Email")]
        [EmailAddress(ErrorMessage = "Некоректна пошта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не вказаний пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}