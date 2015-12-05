using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LectureSchedulingTool.Models
{
    public static class GetString
    {
        public static string GetContStr(this HtmlHelper helper, string name, string lang)
        {
            using (SchedulingContext data = new SchedulingContext())
            {
                var translation = data.Localization.FirstOrDefault(x => x.Name == name && x.Lang == lang);
                if (translation != null) return translation.Text;
            }
            //А если такой строки нет, то надо об этом сообщить.
            return "[No " + name + " for " + lang + "]";
        }
    }
}