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
    /// Interaction logic for ListOfLessons.xaml
    /// </summary>
    public partial class ListOfLessons : Page
    {
        readonly LessonsRepository _lessonRepository = new LessonsRepository();

        //List<Button> _buttons = new List<Button>();
        public ListOfLessons()
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

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LessonsList.Visibility = Visibility.Collapsed;
            Page2.Content = new LearningWindow(LessonsList.SelectedItem.ToString());
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
