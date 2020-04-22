﻿using System;

namespace RobotLib
{
    public class DrawingTools
    {
        
        public double A { get => a; set => a = value; }
        private double a;
        public double B { get => b; set => b = value; }
        private double b;
        public int XMax { get => xMax; set => xMax = value; }
        private int xMax;
        public int YMax { get => yMax; set => yMax = value; }
        private int yMax;

        

        public DrawingTools(double a, double b)
        {
            A = a;
            B = b;
        }

        public void Init()
        {
            

        }


        public double GetAlfa(double x, double y)
        {
            double calcQ1 = ((Math.Pow(x, 2) + Math.Pow(y, 2) - Math.Pow(a, 2) - Math.Pow(b, 2)) / (2 * a * b));
            double beta = Math.Acos(calcQ1);

            double calcQ2y = (b * Math.Sin(beta));
            double calcQ2x = (a + (b * Math.Cos(beta)));

            double alfa = Math.Atan2(y , x) - Math.Atan2(calcQ2y,calcQ2x);

            return ToDegres(alfa);
        }

        public double GetBeta(double x, double y)
        {
            double calcQ1 = ((Math.Pow(x, 2) + Math.Pow(y, 2) - Math.Pow(a, 2) - Math.Pow(b, 2)) / (2 * a * b));
            double beta = Math.Acos(calcQ1);

            double calcQ2y = (b * Math.Sin(beta));
            double calcQ2x = (a + (b * Math.Cos(beta)));

            double alfa = Math.Atan2(y, x) - Math.Atan2(calcQ2y, calcQ2x);

            return ToDegres(beta);
        }


        private double ToDegres(double rad)
        {
            return Math.Round((180 / Math.PI) * rad);
        }

        private double ToRadians(double val)
        {
            return Math.Round((Math.PI / 180) * val);
        }

    }
}  