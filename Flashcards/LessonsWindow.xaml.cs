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
    /// Interaction logic for LessonsWindow.xaml
    /// </summary>
    public partial class LessonsWindow : Window
    {
        LessonRepository _lessonRepository = new LessonRepository();
        List<Button> _buttons = new List<Button>();
        public LessonsWindow()
        {
            InitializeComponent();
            
            List<Lesson> lessons = _lessonRepository.UploadLessons();

            foreach (var lesson in lessons)
            {
                Button newBtn = new Button();

                newBtn.Content = lesson.Name;
                //newBtn.Name = "Button " + lesson.Name;

                _buttons.Add(newBtn);

                sp.Children.Add(newBtn);
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
