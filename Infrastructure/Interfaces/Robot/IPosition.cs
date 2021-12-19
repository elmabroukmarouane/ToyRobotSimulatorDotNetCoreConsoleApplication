using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Robot
{
    /// <summary>
    /// Interface pour indiquer la position du Robot
    /// </summary>
    public interface IPosition
    {
        IPoint Point { get; set; }
    }
}
