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
        public double Poeng { get;  }
        public string photoUrl { get; set; }

        public GameViewModel(GameModel game)
        {
            Id = game.Id;
            Poeng = game.Poeng;
            photoUrl = game.Photos[game.Index].Url;
            //PlayCount = playCount;
            //IsSolved = isSolved;
            //Numbers = numbers;
            //GameTimer = gameTimer;
        }

       
    }
}
