using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Flashcards.Core.Models;
using Flashcards.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Flashcards.Core.ViewModels
{
    public class LessonViewModel : MvxViewModel
    {
        private ObservableCollection<WordModel> _words = new ObservableCollection<WordModel>();

        public ObservableCollection<WordModel> Words
        {
            get { return _words; }
            set { SetProperty(ref _words, value); }
        }

        private string _meaning;

        public string Meaning
        {
            get { return _meaning; }
            set { SetProperty(ref _meaning, value); }
        }
        private string _foreign;

        public string Foreign
        {
            get { return Foreign; }
            set { SetProperty(ref _foreign, value); }
        }
        private string _notes;

        public string Notes
        {
            get { return _notes; }
            set { SetProperty(ref _notes, value); }
        }


    }
}
