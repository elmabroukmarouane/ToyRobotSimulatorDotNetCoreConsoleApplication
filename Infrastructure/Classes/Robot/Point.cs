using Infrastructure.Interfaces.Robot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Classes.Robot
{
    /// <summary>
    /// Classe pour indiquer le point où se situe la position du Robot
    /// </summary>
    public class Point : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
