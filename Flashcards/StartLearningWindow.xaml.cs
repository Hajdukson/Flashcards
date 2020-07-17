using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Diagnostics;
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
        readonly ILearning _lesson;
        string _meaning;
        public StartLearningWindow(Lesson lesson)
        {
            InitializeComponent();

            _lesson = lesson;

            Word word = _lesson.RetriveDrawnWord();
            drawnWord.Content = word.Foreign;
            description.Text = word.Notes;
            _meaning = word.Meaning;
        }

        private void Check_Word(object sender, RoutedEventArgs e)
        {
            if (_lesson.RetriveAnswer(enteredWord.Text, _meaning))
                MessageBox.Show("Correct ans");
            else
                MessageBox.Show("Incorrect ans");

            Word word = _lesson.RetriveDrawnWord();

            if (word != null)
            {
                drawnWord.Content = word.Foreign;
                description.Text = word.Notes;
                _meaning = word.Meaning;
            }
            else
                MessageBox.Show("The lesson was finished.");
        }
    }
}
