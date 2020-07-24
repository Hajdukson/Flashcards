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
        readonly INewLesson _lessonRepository = new LessonsRepository();
        readonly Lesson _lesson;
        public LearningWindow(string lessonName)
        {
            InitializeComponent();

            _lesson = _lessonRepository.Lessons.Find(lesson => lesson.Name == lessonName);
        }
        private void Add_Word(object sender, RoutedEventArgs e)
        {
            AddWordWindow addWordWindow = new AddWordWindow(_lesson);
            addWordWindow.Show();
        }
        private void Start_Learning(object sender, RoutedEventArgs e)
        {
            if (_lesson.Words.Count < 2)
                MessageBox.Show("Add two words at least.");
            else
            { 
                StartLearningWindow startLearningWindow = new StartLearningWindow(_lesson);
                startLearningWindow.Show();
            }
        }
        private void Edit_Word(object sender, RoutedEventArgs e)
        {

        }
        private void Delete_lesson(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure?", "Delete lesson", MessageBoxButton.YesNo);
        }
    }
}
