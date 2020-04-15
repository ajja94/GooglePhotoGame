using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleGame.ViewModel
{
    public class GameViewModel
    {
        public string Id { get; }
        public int PlayCount { get; set; }
        public bool IsSolved { get; set; }
        public char[] Numbers { get; set; }
        public int GameTimer { get; set; }

        public GameViewModel(string id, int playCount, bool isSolved, char[] numbers, int gameTimer)
        {
            Id = id;
            PlayCount = playCount;
            IsSolved = isSolved;
            Numbers = numbers;
            GameTimer = gameTimer;
        }
    }
}
