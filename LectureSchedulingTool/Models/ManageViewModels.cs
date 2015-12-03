using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Configuration;

namespace LectureSchedulingTool.Models
{
    public class IndexViewModel
    {
        public bool BrowserRemembered { get; set; }

        [Required]
        [Range((int)1, (int)10)]
        [Display(Name = "Кол-во занятий в день")]
        public int LessonsCount { get; set; }

        [Required]
        [Range((int)5, (int)100)]
        [Display(Name = "Кол-во эелементов на странице")]
        public int ElementsOnPage { get; set; }

        [Required]
        [Range((int)1, (int)100)]
        [Display(Name = "Кол-во эелементов на странице")]
        public int WeeksAmount { get; set; }

        public IndexViewModel()
        {
            LessonsCount = Int32.Parse(ConfigurationManager.AppSettings["LessonsCount"]);
            ElementsOnPage = Int32.Parse(ConfigurationManager.AppSettings["ElementsOnPage"]);
            WeeksAmount = Int32.Parse(ConfigurationManager.AppSettings["WeeksAmount"]);
        }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Текущий пароль")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} должен быть как минимум {2} символов в длинну.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение нового пароля")]
        [Compare("NewPassword", ErrorMessage = "Новый пароль и подтверждение нового пароля не совпадают.")]
        public string ConfirmPassword { get; set; }
    }

    public class WeeksCountItem
    {
        public int WeeksCount;
        public string WeeksText;

        public WeeksCountItem()
        {

        }
        public WeeksCountItem(int WeeksCount, string WeeksText)
        {
            this.WeeksCount = WeeksCount;
            this.WeeksText = WeeksText;
        }
    }
}