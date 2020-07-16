﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    public class LessonRepository : ILessonRepository
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

            var newLesson = new Lesson(lesson.Name);

            if (!File.Exists(_dbName))
                File.WriteAllText(_dbName, lessonName);
            else
                File.AppendAllText(_dbName, lessonName);

            UploadLessons();
        }
        public ObservableCollection<string> UploadLessons()
        {
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
