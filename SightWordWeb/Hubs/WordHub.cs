using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SightWordWeb.Models;
using System.Linq;

namespace SightWordWeb.Hubs
{
    public class WordHub : Hub
    {

        static WordHub() {
            _testWordList.Add(new Word("One"));
            _testWordList.Add(new Word("Two"));
            _testWordList.Add(new Word("Three"));
            _testWordList.Add(new Word("Four"));
            _testWordList.Add(new Word("Five"));
            _testWordList.Add(new Word("Six"));
        }

        public WordHub()
        {
            _currentWordList = _testWordList;
        }

        private readonly WordList<Word> _currentWordList;
        private static WordList<Word> _testWordList = new WordList<Word>();

        public async Task StartWordList(string nameOfWordList) {
            // Find word list by name and send the first word from a random order.


            await Clients.All.SendAsync("ReceiveWord", _currentWordList.First(w => !w.IsCorrectlyAnswered));
        }

        public async Task UpdateWordStatus(string word, string status)
        {
            if (status == "Correct") {
                _currentWordList.Single(w => w.Value == word).IsCorrectlyAnswered = true;
            }
            if (!_currentWordList.IsComplete) {
                var nextWord = _currentWordList.GetNextWord();
                await Clients.All.SendAsync("ReceiveWord", nextWord);
            } else {
                await Clients.All.SendAsync("WordListComplete");
            }

        }
    }
}
