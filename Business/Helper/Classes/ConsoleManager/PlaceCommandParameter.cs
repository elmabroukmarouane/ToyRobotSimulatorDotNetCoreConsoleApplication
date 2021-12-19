using Business.Helper.Interfaces.ConsoleManager;
using Infrastructure.Classes.Robot;
using Infrastructure.Enums.Robot;
using Infrastructure.Interfaces.Robot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Helper.Classes.ConsoleManager
{
    /// <summary>
    /// Classe pour stocker les paramètres de la command 'PLACE'
    /// </summary>
    public class PlaceCommandParameter : IPlaceCommandParameter
    {
        public IPosition Position { get; set; }
        public Direction Direction { get; set; }

        public PlaceCommandParameter(Position position, Direction direction)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            Direction = direction;
        }
    }
}
