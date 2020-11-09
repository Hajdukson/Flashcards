using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Flashcards.Core
{
    public class LessonsPageViewModel : BaseViewModel, IItems
    {
        public ObservableCollection<LessonViewModel> Lessons { get; set; } = new ObservableCollection<LessonViewModel>();
        public string NewLessonName { get; set; }

        public LessonsPageViewModel()
        {
            AddNewLessonCommand = new RelayCommand(AddNewItem);
        }
        public ICommand AddNewLessonCommand { get; set; }

        public void AddNewItem()
        {
            LessonViewModel newLesson = new LessonViewModel
            {
                LessonName = NewLessonName,
                Id = Lessons.Count + 1
            };

            Lessons.Add(newLesson);

            NewLessonName = string.Empty;
        }
    }
}
