using System.ComponentModel.DataAnnotations;
using System;
using System.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace LectureSchedulingTool.Models
{
    public class IndexViewModel
    {
        public bool BrowserRemembered { get; set; }

        [Required]
        [Range((int)1, (int)3)]
        public int WeeksCount { get; set; }

        [Required]
        [Range((int)1, (int)52)]
        public int WeeksAmount { get; set; }

        [Required]
        [Range((int)1, (int)10)]
        public int LessonsCount { get; set; }

        [Required]
        [Range((int)1, (int)10)]
        public int LessonsAmount { get; set; }

        [Required]
        [Range((int)5, (int)100)]
        public int ElementsOnPage { get; set; }

        [NotMapped]
        public bool HaveDataInTables
        {
            get
            {
                SchedulingContext DB = new SchedulingContext();

                try
                {
                    if (DB.Faculty.Count() > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    return true;
                }
            }
        }

        public IndexViewModel()
        {
            WeeksCount = Int32.Parse(ConfigurationManager.AppSettings["WeeksCount"]);
            WeeksAmount = Int32.Parse(ConfigurationManager.AppSettings["WeeksAmount"]);
            LessonsCount = Int32.Parse(ConfigurationManager.AppSettings["LessonsCount"]);
            LessonsAmount = Int32.Parse(ConfigurationManager.AppSettings["LessonsAmount"]);
            ElementsOnPage = Int32.Parse(ConfigurationManager.AppSettings["ElementsOnPage"]);
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