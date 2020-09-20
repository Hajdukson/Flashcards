using Flashcards.Core.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Flashcards.Core.ViewModels
{
    public class LessonBookViewModel : MvxViewModel
    {
        public LessonBookViewModel()
        {
            AddLessonCommand = new MvxCommand(AddLesson);
        }
        public IMvxCommand AddLessonCommand { get; set; }
        public void AddLesson()
        {
            LessonModel lesson = new LessonModel
            {
                LessonName = this.LessonName
            };

            LessonName = string.Empty;
            Lessons.Add(lesson);
        }
        private ObservableCollection<LessonModel> _lessons = new ObservableCollection<LessonModel>();
        public ObservableCollection<LessonModel> Lessons
        {
            get { return _lessons; }
            set { SetProperty(ref _lessons, value); }
        }

        private string _lessonName;
        public string LessonName
        {
            get { return _lessonName; }
            set { SetProperty(ref _lessonName, value); }
        }
       
    }
}
