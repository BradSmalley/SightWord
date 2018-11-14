using System;
namespace SightWordWeb.Models
{
    public class Word
    {

        public Word()
        {

        }

        public Word(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public bool IsCorrectlyAnswered { get; set; }

        public override string ToString()
        {
            return this.Value;
        }

    }
}
