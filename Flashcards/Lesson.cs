using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    class Lesson
    {
        public string Name { get; private set; }

        public Lesson(string name)
        {
            Name = name;
        }
    }
}
