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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flashcards
{
    /// <summary>
    /// Interaction logic for LearningWindow.xaml
    /// </summary>
    public partial class LearningWindow : Page
    {
        readonly LessonRepository _lessonRepository = new LessonRepository();
        readonly Lesson _lesson;
        public LearningWindow(string lessonName)
        {
            InitializeComponent();

            _lesson = _lessonRepository.Lessons.Find(lesson => lesson.Name == lessonName);
        }
        private void Add_Word(object sender, RoutedEventArgs e)
        {
            Word word = new Word(Foreign.Text, Meaning.Text, Description.Text);

            _lesson.NewWord(word);
        }
        private void Start_Learning(object sender, RoutedEventArgs e)
        {

        }
        private void Edit_Word(object sender, RoutedEventArgs e)
        {

        }
    }
}
