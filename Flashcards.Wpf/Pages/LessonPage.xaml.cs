using Flashcards.Core;
using System.Windows.Controls;

namespace Flashcards.Wpf
{
    /// <summary>
    /// Interaction logic for LessonPage.xaml
    /// </summary>
    public partial class LessonPage : Page
    {
        public LessonPage()
        {
            InitializeComponent();
            DataContext = new LessonPageViewModel();
        }
    }
}
