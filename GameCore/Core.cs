﻿using System;

namespace GameCore
{
    public class Core
    {
        public double[] getPossition()
        {
            // get the pointed pos from user
          double[] userPos = {  123, 345  };
            return userPos;

        }

        public void calculateDifference()
        {
            double picLat = 124;
            double picLong = 334;
            // take the absolute value of possition and calc
            double[] picturePos = { picLat, picLong };
            double[] userPos = getPossition();


        }



    }
}
