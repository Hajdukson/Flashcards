namespace Flashcards.Core
{
    public class WordViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Flashcard { get; set; }
        public string FlashcardMeaning { get; set; }
        public string Sample{ get; set; }
    }
}
