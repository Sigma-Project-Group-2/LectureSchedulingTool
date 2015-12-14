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

        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "Required")]
        [Range(1, 3, ErrorMessageResourceType = typeof(Resources.ValidationMessages),
                ErrorMessageResourceName = "RangeHours")]
        [Display(ResourceType = typeof(Resources.Names), Name = "WeeksCount")]
        public int WeeksCount { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "Required")]
        [Range(1, 52, ErrorMessageResourceType = typeof(Resources.ValidationMessages),
                ErrorMessageResourceName = "RangeHours")]
        [Display(ResourceType = typeof(Resources.Names), Name = "WeeksAmount")]
        public int WeeksAmount { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
             ErrorMessageResourceName = "Required")]
        [Range(1, 10, ErrorMessageResourceType = typeof(Resources.ValidationMessages),
                ErrorMessageResourceName = "RangeHours")]
        [Display(ResourceType = typeof(Resources.Names), Name = "LessonsCount")]
        public int LessonsCount { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
             ErrorMessageResourceName = "Required")]
        [Range(1, 10, ErrorMessageResourceType = typeof(Resources.ValidationMessages),
                ErrorMessageResourceName = "RangeHours")]
        [Display(ResourceType = typeof(Resources.Names), Name = "LessonsAmount")]
        public int LessonsAmount { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "Required")]
        [Range(5, 100, ErrorMessageResourceType = typeof(Resources.ValidationMessages),
                ErrorMessageResourceName = "RangeHours")]
        [Display(ResourceType = typeof(Resources.Names), Name = "ElementsOnPage")]
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
        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "Required")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Names), Name = "OldPassword")]
        public string OldPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "StringLength", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Names), Name = "NewPassword")]
        public string NewPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ValidationMessages),
            ErrorMessageResourceName = "Required")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Names), Name = "ConfirmPassword")]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(Resources.Names),
            ErrorMessageResourceName = "ComparePassword")]
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