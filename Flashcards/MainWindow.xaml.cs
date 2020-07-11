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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly LessonRepository _lessonRepository = new LessonRepository();
        public MainWindow()
        {
            InitializeComponent();

            if(!File.Exists(Directory.GetCurrentDirectory() + @"\Lessons"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Lessons");
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        private void Select_lesson(object sender, RoutedEventArgs e)
        {
            Page1.Content = new ListOfLessons();
        }
        private void Add_lesson(object sender, RoutedEventArgs e)
        {
            if(LessonName.Text.ToLower() != "name the lesson")
            {
                var lesson = new Lesson(LessonName.Text);

                if(_lessonRepository.Lessons != null)
                { 
                    var retriveExistingLesson = _lessonRepository.Lessons.Find(retriveLesson => retriveLesson.Name == LessonName.Text);
                    if (retriveExistingLesson == null)
                    {
                        _lessonRepository.NewLesson(lesson);
                    }
                }
                else
                    _lessonRepository.NewLesson(lesson);
            }
        }
    }
}
