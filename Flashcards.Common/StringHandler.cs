using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Flashcards.Common
{
    public static class StringHandler
    {
        public static string RetrivAndHideWordInDescription(string word, string notes)
        {
            var myregex = new Regex(word, RegexOptions.IgnoreCase);

            var hide = "_";
            for (int i = 0; i < word.Length - 1; i++)
                hide += '_';

            return myregex.Replace(notes, hide);
        }
    }
}
