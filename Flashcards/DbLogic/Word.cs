﻿namespace Flashcards
{
    public class Word : EntityBase
    {
        public string Foreign { get; set; }
        public string Meaning { get; set; }
        public string Notes { get; set; }
        public Word(string foreign, string meaning, string notes)
        {
            Foreign = foreign;
            Meaning = meaning;
            Notes = notes;
        }

        protected override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(Foreign))
                isValid = false;

            if (string.IsNullOrWhiteSpace(Meaning))
                isValid = false;

            return isValid;   
        }
    }
}
