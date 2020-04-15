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

        public GameViewModel(Guid id ,double poeng)
        {
            Id = id;
            Poeng = poeng;
            //PlayCount = playCount;
            //IsSolved = isSolved;
            //Numbers = numbers;
            //GameTimer = gameTimer;
        }

       
    }
}
