using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Domain.Model
{
    public class PhotoModel
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public Coordinates Coordinates { get; set; }

        public void AddCoordinatesAsString(string coordinates)
        {
            Coordinates = new Coordinates();
            Coordinates.AddAsString(coordinates);
        }
    }
}
