using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    public class Lesson
    {
        public string Name { get; private set; }

        public List<Word> Words
        {
            get
            {
                var list = new List<Word>();

                if (File.Exists(Directory.GetCurrentDirectory() + @"\Lessons\" + Name + ".txt"))
                { 
                    var lines = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\Lessons\" + Name + ".txt");
                    foreach (var line in lines)
                    {
                        var vs = line.Split(';');
                        var foreign = vs[0];
                        var meaning = vs[1];
                        var notes = vs[2];
                        list.Add(new Word(foreign, meaning, notes));
                    }
                    return list;
                }

                return null;
            }
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
    }
}
