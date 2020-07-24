using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    interface INewLesson
    {
        List<Lesson> Lessons { get; }
        void NewLesson(Lesson lesson);
    }
}
