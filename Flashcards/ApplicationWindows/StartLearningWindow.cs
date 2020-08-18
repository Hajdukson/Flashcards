using OpenTK;
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
using Flashcards.Common;

namespace Flashcards
{
    /// <summary>
    /// Interaction logic for StartLearningWindow.xaml
    /// </summary>
    public partial class StartLearningWindow : Window
    {
        readonly ILearning _lesson;
        string _meaning;
        Word _word;

        public StartLearningWindow(Lesson lesson)
        {
            InitializeComponent();

            _lesson = lesson;

            Word word = _lesson.RetriveDrawnWord();
            _word = word;
            drawnWord.Text = word.Meaning;

            description.Text = StringHandler.RetrivAndHideWordInDescription(
                word.Foreign, word.Notes);

            _meaning = word.Foreign;
            
        }

        private void NextWord_Button(object sender, RoutedEventArgs e)
        {
            Word word = _lesson.RetriveDrawnWord();
            _word = word;
            if (word != null)
            {
                drawnWord.Text = word.Meaning;
                description.Text = StringHandler.RetrivAndHideWordInDescription(
                    word.Foreign, word.Notes);
                _meaning = word.Foreign;
            }
            else
            {
                MessageBox.Show("The lesson was finished.");
                Close();
            }
            enteredWord.Text = "";
            trueImg.Visibility = Visibility.Collapsed;
            falseImg.Visibility = Visibility.Collapsed;
            checkWord.Visibility = Visibility.Visible;
            nextWord.Visibility = Visibility.Collapsed;
        }
        private void WordHandler()
        {
            if (_lesson.RetriveAnswer(enteredWord.Text.ToLower(), _meaning))
            {
                description.Text = _word.Notes;
                trueImg.Visibility = Visibility.Visible;
            }
            else
            {
                enteredWord.Text = _word.Foreign;
                description.Text = _word.Notes;
                falseImg.Visibility = Visibility.Visible;
            }
            
            checkWord.Visibility = Visibility.Collapsed;
            nextWord.Visibility = Visibility.Visible;
        }
        private void CheckWord_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
                WordHandler();
        }

        private void Check_Word(object sender, RoutedEventArgs e)
        {
            WordHandler();
        }

        private void NextWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                WordHandler();
            }
        }
    }
}
