using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace LectureSchedulingTool.Models
{
    public class LocalizationContext : DbContext
    {
        public DbSet<Localization> Localization { get; set; }
    }

    public class Localization
    {
        [Key]
        public int id_localization { get; set; }
        [Required]
        public string name { set; get; }
        [Required]
        public string language { get; set; }
        [Required]
        public string text { get; set; }
    }

    public static class Localizator
    {
        public static string Localizate(this HtmlHelper helper, string name, string language)
        {
            using (LocalizationContext data = new LocalizationContext())
            {
                var translation = data.Localization.FirstOrDefault(x => x.name == name && x.language == language);
                if (translation != null) return translation.text;
            }
            //А если такой строки нет, то надо об этом сообщить.
            return "[No " + name + " for " + language + "]";
        }
    }
}