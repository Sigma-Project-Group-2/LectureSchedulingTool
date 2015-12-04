using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

namespace LectureSchedulingTool.Models
{
    public class SchedulingAlgorithm
    {
        private SchedulingContext DB = new SchedulingContext();

        public void Generate()
        {
            List<Students_Group_Day> sg_day = new List<Students_Group_Day>();
            foreach (var sg in DB.Students_group)
                sg_day.Add(new Students_Group_Day(sg.id_students_group));

            List<Teacher_Day> t_day = new List<Teacher_Day>();
            foreach (var t in DB.Teacher)
                t_day.Add(new Teacher_Day(t.id_teacher));

            List<Classroom_Day> c_day = new List<Classroom_Day>();
            foreach (var c in DB.Classroom)
                c_day.Add(new Classroom_Day(c.id_classroom));

            for (int i = 0; i < DB.Faculty.Count(); i++)
            {

            }

            for (int i = 0; i < DB.Faculty.Count(); i++)
            {

            }
        }

        private class Students_Group_Day
        {
            public readonly int id_students_group;

            List<List<bool>> day;

            public Students_Group_Day(int id_students_group)
            {
                this.id_students_group = id_students_group;

                day = new List<List<bool>>();

                int lessons = Int32.Parse(ConfigurationManager.AppSettings["LessonsCount"]);

                for (int i = 0; i < 5; i++)
                {
                    day[i] = new List<bool>(lessons);

                    for (int j = 0; j < lessons; j++)
                        day[i][j] = false;
                }
            }
        }
        private class Teacher_Day
        {
            public readonly int id_teacher;

            List<List<bool>> day;

            public Teacher_Day(int id_teacher)
            {
                this.id_teacher = id_teacher;

                day = new List<List<bool>>();

                int lessons = Int32.Parse(ConfigurationManager.AppSettings["LessonsCount"]);

                for (int i = 0; i < 5; i++)
                {
                    day[i] = new List<bool>(lessons);

                    for (int j = 0; j < lessons; j++)
                        day[i][j] = false;
                }
            }
        }
        private class Classroom_Day
        {
            public readonly int id_classroom;

            List<List<bool>> day;

            public Classroom_Day(int id_classroom)
            {
                this.id_classroom = id_classroom;

                day = new List<List<bool>>();

                int lessons = Int32.Parse(ConfigurationManager.AppSettings["LessonsCount"]);

                for (int i = 0; i < 5; i++)
                {
                    day[i] = new List<bool>(lessons);

                    for (int j = 0; j < lessons; j++)
                        day[i][j] = false;
                }
            }
        }

        private List<Lesson> GetEmptyLessons(int id_faculty, bool for_internal_groups)
        {
            List<Students_group_load> sgl = DB.Students_group_load.ToList();
            List<Lesson> lessons = new List<Lesson>();

            int weeks_amount = Int32.Parse(ConfigurationManager.AppSettings["WeeksAmount"]);
            int weeks_count = Int32.Parse(ConfigurationManager.AppSettings["WeeksCount"]);
            int lesson_amount = Int32.Parse(ConfigurationManager.AppSettings["LessonsAmount"]);

            int min_hours = weeks_amount * 2 / weeks_count;

            for (int i = 0; sgl.Count != 0; i++)
            {
                if (sgl[i].hours / min_hours == 1)
                {
                    lessons.Add(new Lesson { id_students_group_load = sgl[i].id_students_group_load });
                    sgl.Remove(sgl[i]);
                }
                else
                {
                    lessons.Add(new Lesson { id_students_group_load = sgl[i].id_students_group_load });
                    sgl[i].hours -= min_hours;
                }
            }

            return lessons;
        }
    }
}