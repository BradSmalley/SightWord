using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SightWordWeb.Models;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace SightWordWeb.Hubs
{
    public class WordHub : Hub
    {
        private static bool IsFirstRun = true;

        public WordHub()
        {
            if (IsFirstRun)
            {
                _testWordList.Add(new Word("One"));
                _testWordList.Add(new Word("Two"));
                _testWordList.Add(new Word("Three"));
                _testWordList.Add(new Word("Four"));
                _testWordList.Add(new Word("Five"));
                _testWordList.Add(new Word("Six"));
                IsFirstRun = false;
            }
            _currentWordList = _testWordList;
        }

        private readonly WordList _currentWordList;
        private static WordList _testWordList = new WordList();

        public async Task StartWordList(string nameOfWordList) {
            // Find word list by name and send the first word from a random order.
            await Clients.All.SendAsync("ReceiveWord", _currentWordList.First(w => !w.IsCorrectlyAnswered));
        }

        public async Task RegisterAsReviewer()
        {
            Startup.ReviewerId = Context.ConnectionId;
            await Clients.Client(Context.ConnectionId).SendAsync("Registered", Startup.ReviewerId);
        }

        public async Task UpdateWordStatus(string word, string status)
        {
            if (status == "Correct") {
                _currentWordList.Single(w => w.Value == word).IsCorrectlyAnswered = true;
            }
            if (!_currentWordList.IsComplete) {
                var nextWord = _currentWordList.GetNextWord();
                await Clients.All.SendAsync("ReceiveWord", nextWord, status);
            } else {
                _currentWordList.Reset();
                await Clients.All.SendAsync("WordListComplete");
            }

        }

        public override Task OnConnectedAsync()
        {
            var reviewerId = Startup.ReviewerId;
            if (!string.IsNullOrEmpty(reviewerId))
            {
                Clients.Client(reviewerId).SendAsync("ClientConnected", Context.ConnectionId);
            }
            Clients.Caller.SendAsync("ConnectionSuccess");
            return base.OnConnectedAsync();
        }


        public override Task OnDisconnectedAsync(Exception e)
        {
            return base.OnDisconnectedAsync(e);
        }


    }
}
