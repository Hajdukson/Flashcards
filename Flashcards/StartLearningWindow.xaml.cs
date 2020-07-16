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

            drawnWord.Content = _lesson.RetriveDrawnWord().Foreign;
        }

        private void Check_Word(object sender, RoutedEventArgs e)
        {
            drawnWord.Content = _lesson.RetriveDrawnWord().Foreign;
        }
    }
}
