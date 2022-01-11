using Infrastructure.Interfaces.Robot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Classes.Robot
{
    /// <summary>
    /// Classe pour indiquer la position du Robot
    /// </summary>
    public class Position : IPosition
    {
        public IPoint Point { get; set; }

        public Position(IPoint point)
        {
            Point = point;
        }
    }
}
