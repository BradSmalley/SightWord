using System;
using System.Collections.Generic;
using System.Linq;

namespace SightWordWeb.Models
{
    public class WordList<T> : List<T> where T : Word
    {
        public bool IsComplete { 
            get {
                return !this.Any(w => !w.IsCorrectlyAnswered);
            }
        }

        public Word GetNextWord() {
            // Randomize this - OR - create a random implementation
            return this.First(w => !w.IsCorrectlyAnswered);
        }
    }
}
