using Business.Helper.Interfaces.ConsoleManager;
using Infrastructure.Classes.Robot;
using Infrastructure.Enums.Robot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Helper.Classes.ConsoleManager
{
    public class PlaceCommandParameterParser : IPlaceCommandParameterParser
    {
        // Nombre de paramètres passé à la commande 'PLACE' (X,Y,Direction)
        private const int ParameterCount = 3;

        // Nombre d'éléments d'entrée bruts attendus de l'utilisateur
        private const int CommandInputCount = 2;

        /// <summary>
        /// Méthode responsable de vérifier la position initiale du robot and la direction dans laquelle il se dirige
        /// </summary>
        /// <param name="parameters">Liste des commandes à traiter</param>
        /// <returns>PlaceCommandParameter</returns>
        public IPlaceCommandParameter ParseParameters(string[] parameters)
        {
            // Vérifie que la commande 'PLACE' est bien reformulée
            if (parameters.Length != CommandInputCount)
                throw new ArgumentException("Your 'PLACE' Command is incomplete. Please make sure that you're entering the right format (PLACE X,Y,Direction)");

            // Vérifie que la commande 'PLACE' a bien ces trois paramètres (X,Y,Direction) 
            var commandParams = parameters[1].Split(',');
            if (commandParams.Length != ParameterCount)
                throw new ArgumentException("Your 'PLACE' Command is incomplete. Please make sure that you're entering the right format (PLACE X,Y,Direction)");

            // Vérifie la direction où le Robor se dirige
            if (!Enum.TryParse(commandParams[commandParams.Length - 1], true, out Direction direction))
                throw new ArgumentException("Your 'PLACE' Command has an invalid direction. Please select and enter one of the following directions: NORTH|EAST|SOUTH|WEST");

            var x = Convert.ToInt32(commandParams[0]);
            var y = Convert.ToInt32(commandParams[1]);
            var position = new Position(new Point(x, y));

            return new PlaceCommandParameter(position, direction);
        }
    }
}
