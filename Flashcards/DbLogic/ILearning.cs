using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    interface ILearning
    {
        Word RetriveDrawnWord();
        bool RetriveAnswer(string enteredWord, string drawnWord);
    }
}
