using GameCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleGame.ViewModel
{
    public class GameViewModel
    {
       

        public Guid Id { get; }
        public int Index { get; }
        public double Points { get;  }
        public double SumPoints { get;  }
        public string photoUrl { get; set; }
        //public string Name { get; set; }
        public int AlbumLength { get; }
        public bool IsGameFinished { get; }

        public GameViewModel(GameModel game)
        {
            Id = game.Id;
            Points = game.Points;
            photoUrl = game.Photos[game.Index].Url;
            SumPoints = game.SumPoints;
            Index = game.Index;
            IsGameFinished = game.IsGameFinished;
            //Name = game.Name;
            //PlayCount = playCount;
            //IsSolved = isSolved;
            //Numbers = numbers;
            //GameTimer = gameTimer;
        }

       
    }
}
