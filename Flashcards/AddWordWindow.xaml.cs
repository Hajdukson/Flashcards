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
    /// Interaction logic for AddWordWindow.xaml
    /// </summary>
    public partial class AddWordWindow : Window
    {
        readonly Lesson _lesson;
        public AddWordWindow(Lesson lesson)
        {
            InitializeComponent();

            _lesson = lesson;
        }
        private void Add_Word(object sender, RoutedEventArgs e)
        {
            var word = new Word(Foreign.Text, Meaning.Text, Description.Text);

            if (word.IsValid)
            {
                if (_lesson.Words != null)
                {
                    var retriveExistingWord = _lesson.Words.Find(find => find.Foreign == Foreign.Text);
                    if (retriveExistingWord == null)
                        _lesson.NewWord(word);
                    else
                        MessageBox.Show("The word exist.");

                    Foreign.Text = "Word";
                    Meaning.Text = "Meaning";
                    Description.Text = "Some notes";
                }
                else
                    _lesson.NewWord(word);
            }
            else
                MessageBox.Show("Fill all fields.");
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
