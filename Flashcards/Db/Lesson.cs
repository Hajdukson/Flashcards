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
    public class Lesson : EntityBase
    {
        public string Name { get; private set; }

        public List<Word> Words
        {
            get
            {
                var words = new List<Word>();

                if(Name == "testLesson")
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
                    return words;
                }

                return null;
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
            List<Word> words = Words;

            if (words == null)
                return null;

            Random random = new Random();
            int index = random.Next(0, words.Count);

            return words.ElementAt(index);
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
