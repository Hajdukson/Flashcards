using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Flashcards
{
    /// <summary>
    /// Interaction logic for StartLearningWindow.xaml
    /// </summary>
    public partial class StartLearningWindow : Window
    {
        readonly Lesson _lesson;
        public StartLearningWindow(Lesson lesson)
        {
            InitializeComponent();
            _lesson = lesson;

            DoTillEnd();
        }
        private Word RetriveDrawnWord()
        {
            List<Word> words = _lesson.Words;

            if (words == null)
                return null;

            Random random = new Random();
            int index = random.Next(0, words.Count);

            return words.ElementAt(index);
        }
        private void DoTillEnd()
        {
            drawnWord.Content = RetriveDrawnWord().Foreign;
            int numberOfWords = _lesson.Words.Count;
        }
        private void Check_Word(object sender, RoutedEventArgs e)
        {
            drawnWord.Content = RetriveDrawnWord().Foreign;
        }
    }
}
