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
            Lat = double.Parse(cords[0].Replace(" ", ""), System.Globalization.CultureInfo.InvariantCulture);
            Long = double.Parse(cords[1].Replace(" ", ""), System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
