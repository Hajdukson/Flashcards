using OpenTK.Graphics.ES11;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Flashcards
{
    public class LessonsRepository : ILessonHandler
    {
        private readonly string _dbName = "database.txt";
        public List<Lesson> Lessons
        {
            get
            {
                if(File.Exists(_dbName))
                {   
                    var lines = File.ReadAllLines(_dbName);
                    return lines.Select(line => new Lesson(line)).ToList();
                }
                return null;
            }
        }
        public void NewLesson(Lesson lesson)
        {
            var lessonName = $"{lesson.Name}{Environment.NewLine}";

            if (!File.Exists(_dbName))
                File.WriteAllText(_dbName, lessonName);
            else
                File.AppendAllText(_dbName, lessonName);

            UploadLessons();
        }
        public void DeleteLesson(Lesson lesson)
        {
            var lessonToDelete = Lessons.Find(l => l.Name == lesson.Name);

            Lessons.Remove(lessonToDelete);

            var lines = new List<string>();

            foreach (var line in lines)
            {
                lines.Add(line);
            }

            File.WriteAllLines(_dbName, lines);
        }
        public ObservableCollection<string> UploadLessons()
        {
            if (!File.Exists(_dbName))
                return null;

            var lines = File.ReadAllLines(_dbName);
            
            ObservableCollection<string> lessons = new ObservableCollection<string>();
            foreach (var line in lines)
            {
                lessons.Add(line);
            }

            return lessons;
        }
    }
}
