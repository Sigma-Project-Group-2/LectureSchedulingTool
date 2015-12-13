﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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
                var translation = data.Localization.FirstOrDefault(t => t.name == name && t.language == language);

                if (translation != null)
                    return translation.text;
                else
                    return "[Localization not found]";
            }
        }

        public static string Localizate(string name, string language)
        {
            using (LocalizationContext data = new LocalizationContext())
            {
                var translation = data.Localization.FirstOrDefault(t => t.name == name && t.language == language);

                if (translation != null)
                    return translation.text;
                else
                    return "[Localization not found]";
            }
        }
    }
}