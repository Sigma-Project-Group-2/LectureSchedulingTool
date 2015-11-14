using System.Collections.Generic;
using System.Data.Entity;

namespace LectureSchedulingTool.Models
{
    public class SchedulingContext : DbContext
    {
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Students_group> Students_group { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<Students_group_load> Students_group_load { get; set; }
        public DbSet<Teacher_load> Teacher_load { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
    }
}
