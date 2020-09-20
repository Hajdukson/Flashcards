using Flashcards.Core.ViewModels;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            this.RegisterAppStart<LessonBookViewModel>();
        }
    }
}
