using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Enums.Robot;
using Infrastructure.Interfaces.Robot;

namespace Business.Helper.Interfaces.ConsoleManager
{
    /// <summary>
    /// Interface pour stocker les paramètres de la command 'PLACE'
    /// </summary>
    public interface IPlaceCommandParameter
    {
        IPosition Position { get; set; }
        Direction Direction { get; set; }
    }
}
