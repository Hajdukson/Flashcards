using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    public class Logic
    {
        private readonly Lesson _lesson;
        public Logic()
        {
            
        }
        public Logic(Lesson lesson)
        {
            _lesson = lesson;
        }
        public Word RetriveDrawnWord()
        {
            List<Word> words = _lesson.Words;

            if (words == null)
                return null;

            Random random = new Random();
            int index = random.Next(0, words.Count);

            return words.ElementAt(index);
        }
    }
}
