using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore.Domain.Model
{
    public class GameModel : BaseModel
    {
       // private readonly int[] _numbers;
        private readonly Random _random;
        //public int aTimer;
        private int Poeng;
        public double poeng = 0;

        //public int PlayCount { get; private set; }
        //public bool IsSolved => Enumerable.Range(0, _numbers.Length - 1)
        //                                  .All(i => _numbers[i] == i + 1);

        //public char[] Numbers => Enumerable.Range(0, _numbers.Length)
        //                                   .Select(i => this[i])
        //                                   .ToArray();

        public GameModel(Guid id, int poeng ) : base(id)
        {
            Poeng = poeng;
        }

        public GameModel()
        {
          
        }

        public bool Play()
        {

            //SetTimer();
            //GameTimer();
            GetPossition();
            CalculateDifference();
            UserPoints(poeng);
            //DateTime Starttimer = DateTime.Now;

            return true;
        }
        public double[] GetPossition()
        {
            // get the pointed pos from user
            double[] userPos = { 123, 345 };
            return userPos;

        }

      
        public double CalculateDifference()
        {
           
            // photo possition
            double picLat = 124;
            double picLong = 334;

            // take the absolute value of possition and calc
            double[] picturePos = { picLat, picLong };
            double[] userPos = GetPossition();

            double differenceLat = picturePos[0] - Math.Abs(userPos[0]);
            double differenceLong = picturePos[1] - Math.Abs(userPos[1]);

           double AIAndre = Math.Pow(differenceLat, 2);
           double BIAndre = Math.Pow(differenceLong, 2);

           double C =  Math.Sqrt(AIAndre + BIAndre);

            poeng = 1000 / C;

            return poeng;
        }

        public double UserPoints(double poeng)
        {
            double SumPoeng = 0;

            SumPoeng += poeng;

            return SumPoeng;
        }

        //private DateTime GameTimer()
        //{
        //    return DateTime.Now;
        //  //  var _GameTime =DateTime.Now - Starttime;
        ////}
        

        //private void gameTimer()
        //{
        //    // Create a timer with a one second interval.
        //    //aTimer = 0;
        //    // Hook up the Elapsed event for the timer. 
        //    //aTimer.Elapsed += OnTimedEvent;
        //    //aTimer.AutoReset = true;
        //    //aTimer.Enabled = true;
        //}


        //private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        //{
        //    Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
        //        e.SignalTime);
        //}

    }
}
