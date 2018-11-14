using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SightWordWeb.Models
{
    public class WordList : List<Word> 
    {
        public string Name { get; set; }

        public bool IsComplete { 
            get {
                return !this.Any(w => !w.IsCorrectlyAnswered);
            }
        }

        public Word GetNextWord() {
            // Randomize this - OR - create a random implementation

            var incompleteWords = this.Where(w => !w.IsCorrectlyAnswered).ToArray();
            var count = incompleteWords.Count();

            var random = new Random(DateTime.Now.Millisecond);
            var randomIndex = random.Next(0, count - 1);

            return incompleteWords[randomIndex];
        }

        public void Reset()
        {
            foreach (var word in this)
            {
                word.IsCorrectlyAnswered = false;
            }
        }

    }
}
