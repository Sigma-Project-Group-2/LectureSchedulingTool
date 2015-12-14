using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace LectureSchedulingTool.Models.CustomAttributes
{
    public class CorrectHours : ValidationAttribute
    {
        public CorrectHours()
        {

        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                ErrorMessageResourceName = "CorrectHours1";
                return false;
            }

            int hours = Convert.ToInt32(value);
            int weeks_amount = Int32.Parse(ConfigurationManager.AppSettings["WeeksAmount"]);
            int weeks_count = Int32.Parse(ConfigurationManager.AppSettings["WeeksCount"]);
            int lesson_amount = Int32.Parse(ConfigurationManager.AppSettings["LessonsAmount"]);

            int min_hours = weeks_amount * lesson_amount / weeks_count;

            if (hours % min_hours != 0)
            {
                ErrorMessageResourceName = "CorrectHours2";
                ErrorMessage = ErrorMessageResourceName + " " + min_hours + ".";
                return false;
            }

            return true;
        }
    }
}
