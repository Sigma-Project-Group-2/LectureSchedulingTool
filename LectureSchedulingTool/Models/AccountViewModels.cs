using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LectureSchedulingTool.Models.CustomAttributes;

namespace LectureSchedulingTool.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "EmailInCorrect")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "PasswordRequired")]
        [DataType(DataType.Password)]
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
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "SecretCodeRequired")]
        [SecretCode(ErrorMessageResourceType = typeof(Resources.ValidationMessages))]
        public string SecretCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "PasswordRequired")]
        [StringLength(100, MinimumLength = 6, ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "PasswordCodeLength")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "PasswordConfirmationRequired")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "PasswordConfirmationEquality")]
        public string ConfirmPassword { get; set; }        
    }
}
