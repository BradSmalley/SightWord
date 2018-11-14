using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SightWordWeb.Models;

namespace SightWordWeb.Infrastructure
{
    public class FileWordListWriter : IWordListWriter
    {
        public void Save(WordList wordList)
        {
            using (var file = File.Create(wordList.Name + ".lst"))
            using (var writer = new StreamWriter(file))
            {
                foreach (var word in wordList)
                {
                    writer.WriteLine(word.Value);
                }
            }
        }
    }
}
