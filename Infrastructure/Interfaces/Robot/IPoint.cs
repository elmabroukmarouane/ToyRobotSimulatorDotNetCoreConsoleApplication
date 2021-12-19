using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Robot
{
    /// <summary>
    /// Interface pour indiquer le point où se situe la position du Robot
    /// </summary>
    public interface IPoint
    {
        int X { get; set; }
        int Y { get; set; }
    }
}
