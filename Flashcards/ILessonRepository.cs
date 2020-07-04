using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    interface ILessonRepository
    {
        void NewLesson(Lesson lesson);
        List<Lesson> UploadLessons(Lesson lesson = null);
    }
}
