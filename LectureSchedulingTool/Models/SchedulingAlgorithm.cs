using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureSchedulingTool.Models;

namespace LectureSchedulingTool.Models
{
    public class SchedulingAlgorithm
    {
        private SchedulingContext DB = new SchedulingContext();

        private List<Lesson> scheduling_lessons;
        private List<LessonGen> lessons_gens;

        public SchedulingAlgorithm()
        {
            scheduling_lessons = new List<Lesson>();
            lessons_gens = new List<LessonGen>();
        }

        public void Run()
        {
            
        }

        public List<Lesson> GetLessons()
        {
            if (scheduling_lessons == null || scheduling_lessons.Count == 0)
                return null;
            else
                return scheduling_lessons;
        }
    }

    public class LessonGen : Lesson
    {
        public bool create_window_in_teacher_scheduling;
        public bool remove_window_in_teacher_scheduling;

        public int GetMark()
        {
            int mark = 0;

            if (create_window_in_teacher_scheduling == true)
                mark--;
            else
                mark++;

            if (remove_window_in_teacher_scheduling == true)
                mark++;
            else
                mark--;



            return mark;
        }

        public Lesson GetLesson()
        {
            return new Lesson(week_count, lesson_count, id_classroom, id_students_group_load, id_teacher_load);
        }
    }
}
