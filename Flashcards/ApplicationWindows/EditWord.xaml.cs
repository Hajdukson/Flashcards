using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Flashcards.ApplicationWindows
{
    /// <summary>
    /// Interaction logic for EditWord.xaml
    /// </summary>
    public partial class EditWord : Window
    {
        Lesson _lesson;
        ObservableCollection<Word> listOfWords = new ObservableCollection<Word>();
        public EditWord(Lesson lesson)
        {
            InitializeComponent();
            _lesson = lesson;

            foreach (var word in _lesson.Words)
            {
                listOfWords.Add(word);
            }
            DataGridLesson.ItemsSource = listOfWords;
        }
        private void ApplyChanges_Click(object sender, RoutedEventArgs e)
        {
            List<string> lines = (from word in listOfWords
                                  let line = string.Format("{0};{1};{2}", word.Foreign.ToLower(),
                                  word.Meaning, word.Notes)select line).ToList();

            File.WriteAllLines($"{Directory.GetCurrentDirectory()}/Lessons/{_lesson.Name}.txt", lines);
        }
    }
}
