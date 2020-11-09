using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Flashcards.Core
{
    public class LessonPageViewModel : BaseViewModel, IItems
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public ObservableCollection<WordViewModel> Words { get; set; } = new ObservableCollection<WordViewModel>();
        public string NewFlashcard { get; set; }
        public string NewFleshcardMeaning { get; set; }
        public string NewSample { get; set; }
        public ICommand AddNewWordCommand { get; set; }
        public LessonPageViewModel()
        {
            AddNewWordCommand = new RelayCommand(AddNewItem);
        }
        public void AddNewItem()
        {
            WordViewModel newWord = new WordViewModel
            {
                Flashcard = NewFlashcard,
                FlashcardMeaning = NewFleshcardMeaning,
                Sample = NewSample
            };

            Words.Add(newWord);

            NewFlashcard = string.Empty;
            NewFleshcardMeaning = string.Empty;
            NewSample = string.Empty;
        }
    }
}
