using System.Collections.Generic;
using System.Data.Entity;

namespace LectureSchedulingTool.Models
{
    //Модель базы данных
    public class SchedulingContext : DbContext
    {
        public DbSet<SVM.Faculty> Faculty { get; set; }
        public DbSet<SVM.Department> Department { get; set; }
        public DbSet<SVM.Students_group> Students_group { get; set; }
        public DbSet<SVM.Teacher> Teacher { get; set; }
        public DbSet<SVM.Subject> Subject { get; set; }
        public DbSet<SVM.Classroom> Classroom { get; set; }
        public DbSet<SVM.Students_group_load> Students_group_load { get; set; }
        public DbSet<SVM.Teacher_load> Teacher_load { get; set; }
        public DbSet<SVM.Lesson> Lesson { get; set; }
    }
}
