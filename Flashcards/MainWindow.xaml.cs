﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LessonRepository _lessonRepository = new LessonRepository();
        public MainWindow()
        {
            InitializeComponent();
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
            _lessonRepository.UploadLessons();
            LessonsWindow lessonsWindow = new LessonsWindow();
            
            lessonsWindow.Show();
        }
        private void Add_lesson(object sender, RoutedEventArgs e)
        {
            Lesson lesson = new Lesson(LessonName.Text);
            _lessonRepository.NewLesson(lesson);
        }
    }
}
