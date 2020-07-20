using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    public class Lesson : EntityBase, ILearning
    {
        public string Name { get; private set; }
        private List<Word> _words;
        public List<Word> Words
        {
            get
            {
                var words = new List<Word>();

                //word repo is true
                if (Name == "testLesson")
                {
                    words = new List<Word>
                    {
                        new Word("moon", "księżyc", ""),
                        new Word("sun", "słońce", "the sun is yellow"),
                    };
                    return words;
                }

                if (File.Exists(Directory.GetCurrentDirectory() + @"\Lessons\" + Name + ".txt"))
                {
                    var lines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\Lessons\" + Name + ".txt");
                    foreach (var line in lines)
                    {
                        var vs = line.Split(';');
                        var foreign = vs[0];
                        var meaning = vs[1];
                        var notes = vs[2];
                        words.Add(new Word(foreign, meaning, notes));
                    }
                }
                return words;
            }
        }
        public List<Word> CheckIfWordRepoIsFalse()
        {
            var words = new List<Word>
            {
                new Word(" ", "dsadas", ""),
                new Word("", "dsadd", "notes"),
                new Word("dsad", "", "dsa"),
                new Word("","",""),
                new Word(""," ",""),
                new Word("word","świat", ""),
                new Word("znaczenie","meaning", "")
            };
            return words;
        }
        public Lesson()
        {

        }
        public Lesson(string name)
        {
            Name = name;
            _words = Words;
        }
        public void NewWord(Word word)
        {
            var line = string.Format("{0};{1};{2};{3}", word.Foreign,
                word.Meaning,
                word.Notes,
                Environment.NewLine);

            string dir = Directory.GetCurrentDirectory()  + @"\Lessons\" + Name + ".txt";

            if (!File.Exists(dir))
                File.WriteAllText(dir, line);
            else
                File.AppendAllText(dir, line);
        }
        public Word RetriveDrawnWord()
        {
            if (_words == null || _words.Count == 0)
                return null;

            Random random = new Random();
            int index = random.Next(0, _words.Count);

            return _words.ElementAt(index);
        }
        public bool RetriveAnswer(string enteredWord, string drawnWord)
        {
            var result = false;
            if (enteredWord == drawnWord)
            {
                var findDrawnWord = _words.Find(word => word.Foreign == enteredWord);
                System.Diagnostics.Debug.WriteLine(_words.Count);
                //System.Diagnostics.Debug.WriteLine(findDrawnWord.Foreign);
                _words.Remove(findDrawnWord);
                result = true;
            }
            return result;
        }
        protected override bool Validate()
        {
            var isValid = true;

            if (Name.ToLower() == "name the lesson")
                isValid = false;

            if (string.IsNullOrWhiteSpace(Name))
                isValid = false;

            return isValid;
        }
    }
}
