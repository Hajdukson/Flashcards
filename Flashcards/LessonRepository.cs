using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    class LessonRepository : ILessonRepository
    {
        private string _dbName = "database.txt";
        //public Lesson Retrive(string name)
        //{
        //    var lessons = UploadLessons();
        //    var findLesson = lessons.Find(lesson => lesson.Name == name);

        //    return  findLesson;
        //}

        public void NewLesson(Lesson lesson)
        {
            var lessonName = $"{lesson.Name}{Environment.NewLine}";

            if (!File.Exists(_dbName))
                File.WriteAllText(_dbName, lessonName);
            else
                File.AppendAllText(_dbName, lessonName);

            UploadLessons(lesson);
        }

        public List<Lesson> UploadLessons(Lesson lesson = null)
        {
            var lines = File.ReadAllLines(_dbName);
            var lessons = (lines.Select(line => new Lesson(line))).ToList();

            Console.WriteLine(lessons.Count);

            return lessons;
        }

        
    }
}
