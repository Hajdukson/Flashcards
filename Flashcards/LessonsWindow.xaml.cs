using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Flashcards
{
    /// <summary>
    /// Interaction logic for LessonsWindow.xaml
    /// </summary>
    public partial class LessonsWindow : Window
    {
        readonly LessonRepository _lessonRepository = new LessonRepository();

        //List<Button> _buttons = new List<Button>();
        public LessonsWindow()
        {
            InitializeComponent();

            LessonsList.ItemsSource = _lessonRepository.UploadLessons();

            //foreach (var lesson in lessons)
            //{
            //    Button newBtn = new Button();

            //    newBtn.Content = lesson.Name;
            //    newBtn.Click += new RoutedEventHandler(ButtonsHandler);
            //    //newBtn.Name = "Button " + lesson.Name;
            //    _buttons.Add(newBtn);

            //    sp.Children.Add(newBtn);
            //}
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LessonWin lessonWin = new LessonWin(LessonsList.SelectedItem.ToString());

            lessonWin.Show();
        }

        //private List<LessonWin> LoadWindows(ObservableCollection<string> lessons)
        //{
        //    List<LessonWin> lessonWins = new List<LessonWin>();
        //    for (int i = 0; i < lessons.Count; i++)
        //    {
        //        lessonWins.Add(new LessonWin());
        //    }
        //    return lessonWins;
        //}
        //private void ButtonsHandler(object sender, RoutedEventArgs e)
        //{
        //    LessonWin lessonWin = new LessonWin();
        //    lessonWin.Show();
        //}
    }
}
