using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    interface ILessonHandler
    {
        List<Lesson> Lessons { get; }
        void NewLesson(Lesson lesson);
        void DeleteLesson(Lesson lesson);
    }
}
