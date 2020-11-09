using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Flashcards.Core
{
    public class LessonViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public ICommand OpenLessonCommand{get; set; }
        public LessonViewModel()
        {
            OpenLessonCommand = new RelayCommand(OpenLesson);        }
        public void OpenLesson()
        {

        }
    }
}
