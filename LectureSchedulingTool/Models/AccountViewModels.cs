using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LectureSchedulingTool.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "EmailRequired")]
        //[Display(Name = "Email")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "EmailInCorrect")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "PasswordRequired")]
        [DataType(DataType.Password)]
        //[Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages), 
            ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "EmailInCorrect")]
        //[Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "SecretCodeRequired")]
        [SecretCode(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "InCorrectSecretCode1")]
        //[Display(Name = "Секретный код")]
        public string SecretCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "PasswordRequired")]
        [StringLength(100, MinimumLength = 6, ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "PasswordCodeLength")]
        [DataType(DataType.Password)]
        //[Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "PasswordConfirmationRequired")]
        [DataType(DataType.Password)]
        //[Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "PasswordConfirmationEquality")]
        public string ConfirmPassword { get; set; }        
    }
}
