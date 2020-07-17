namespace Flashcards
{
    public class Word : EntityBase
    {
        public string Foreign { get; private set; }
        public string Meaning { get; private set; }
        public string Notes { get; private set; }
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
            else if (Foreign.ToLower() == "word")
                isValid = false;

            if (string.IsNullOrWhiteSpace(Meaning))
                isValid = false;
            else if (Meaning.ToLower() == "meaning")
                isValid = false;

            return isValid;   
        }
    }
}
