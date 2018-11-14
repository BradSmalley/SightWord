using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SightWordWeb.Models;

namespace SightWordWeb.Infrastructure
{
    public class FileWordListReader : IWordListReader
    {
        public WordList Read(string source, object options = null)
        {
            var name = source.Substring(2, source.Length - 6); // 6 = 2 (characters at begining) + 4 (file extension .lst)
    
            var result = new WordList() { Name = name };
            using (var reader = new StreamReader(source))
            {
                while(!reader.EndOfStream)
                {
                    var word = new Word(reader.ReadLine());
                    result.Add(word);
                }
            }
            return result;
        }
    }
}
