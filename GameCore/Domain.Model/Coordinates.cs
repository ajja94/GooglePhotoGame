using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Domain.Model
{
    public class Coordinates
    {
        public double Lat { get; set; }
        public double Long { get; set; }

        internal void AddAsString(string coordinates)
        {
            var cords = coordinates.Split(",");
            Lat = Convert.ToDouble(cords[0]);
            Long = Convert.ToDouble(cords[1]);
        }
    }
}
