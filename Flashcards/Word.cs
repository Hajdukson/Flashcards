﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    class Word
    {
        public string Foreign { get; private set; }
        public string Meaning { get; private set; }
        public Word(string foreign, string meaning)
        {
            Foreign = foreign;
            Meaning = meaning;
        }
    }
}