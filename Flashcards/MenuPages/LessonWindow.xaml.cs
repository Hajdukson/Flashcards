using Flashcards.ApplicationWindows;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class LessonWindow : Page
    {
        readonly ILessonHandler _lessonRepository = new LessonsRepository();
        Lesson _lesson;
        string _lessonName;
        public LessonWindow(string lessonName)
        {
            InitializeComponent();

            _lessonName = lessonName;

            _lesson = _lessonRepository.Lessons.Find(lesson => lesson.Name == _lessonName);
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
                   { 
                        _lesson.NewWord(word);
                    }
                   else
                        MessageBox.Show("The word exist.");

                    Foreign.Text = "";
                    Meaning.Text = "";
                    Description.Text = "";
                }
                else
                { 
                    _lesson.NewWord(word);
                }
            }
            else
                 MessageBox.Show("Fill all fields.");
        }
        private void Start_Learning(object sender, RoutedEventArgs e)
        {
            if (_lesson.Words.Count < 2)
                MessageBox.Show("Add two words at least.");
            else
            {
                _lesson = _lessonRepository.Lessons.Find(lesson => lesson.Name == _lessonName);
                StartLearningWindow startLearningWindow = new StartLearningWindow(_lesson);
                startLearningWindow.Show();
            }
        }
        private void Edit_Word(object sender, RoutedEventArgs e)
        {
            EditWord editWord = new EditWord(_lesson);
            editWord.Show();
        }
        private void Delete_lesson(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resoult = MessageBox.Show("Are you sure?", "Statment", MessageBoxButton.YesNo);
            if (resoult == MessageBoxResult.Yes)
            { 
                _lessonRepository.DeleteLesson(_lesson);
                File.Delete($"{Directory.GetCurrentDirectory()}/Lessons/{_lesson.Name}.txt");
            }
        }
    }
}
