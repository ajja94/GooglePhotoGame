using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GameCore.Domain.Model
{
    public class GameModel : BaseModel
    {
        public double Points = 0;
        public double SumPoints = 0;
        public List<PhotoModel> Photos { get; set; }
        public int Index { get; set; } = 0;
        public bool IsGameFinished { get; set; } = false;
        //public string Name { get; set; }

        public GameModel(Guid id, int points, int sumPoints, List<PhotoModel> photos) : base(id)
        {
            SumPoints = sumPoints;
            Points = points;
            Photos = photos;
        }

        public GameModel()
        {

        }

        public void Play(Guid id, Coordinates userPos)
        {
            //SetTimer();
            //GameTimer();
            //var picturePos = GetPossition();
            if (IsGameFinished) return;
            CalculateDifference(userPos);
            UserPoints(Points);
            if (Index == Photos.Count - 1)
            {
                IsGameFinished = true;
                return;
            }
            //DateTime Starttimer = DateTime.Now;
            Index++;

            //return true;
        }
        public Coordinates GetPossition()
        {
            //photo long lat 
            return Photos[Index].Coordinates;

        }

        public void CalculateDifference(Coordinates userPos)
        {


            // take the absolute value of possition and calc
            var picturePos = GetPossition();
            // double[] userPos = GetPossition();

            double differenceLat = picturePos.Lat - Math.Abs(userPos.Lat);
            double differenceLong = picturePos.Long - Math.Abs(userPos.Long);

            double AIAndre = Math.Pow(differenceLat, 2);
            double BIAndre = Math.Pow(differenceLong, 2);

            double C = Math.Sqrt(AIAndre + BIAndre);


            Points = 1000 - (C * 100000);
            if (Points <= 0)
            {
                Points = 0;
            }
        }

        public void UserPoints(double points)
        {
            SumPoints += points;
        }
        public void AddGameAlbum(List<PhotoModel> photoModel)
        {
            Photos = photoModel;
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

        //public int ShowScore(Guid id, int poeng)
        //{
        //    return poeng;
        //}
    }
}
