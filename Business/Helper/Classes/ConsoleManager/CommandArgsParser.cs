using Business.Helper.Interfaces.ConsoleManager;
using Infrastructure.Enums.Robot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Helper.Classes.ConsoleManager
{
    /// <summary>
    /// Classe pour traiter les commandes entrées par l'utilisateur sur la console
    /// </summary>
    public class CommandArgsParser : ICommandArgsParser
    {
        protected readonly IPlaceCommandParameterParser _placeCommandParameterParser;

        public CommandArgsParser(IPlaceCommandParameterParser placeCommandParameterParser)
        {
            _placeCommandParameterParser = placeCommandParameterParser ?? throw new ArgumentNullException(nameof(placeCommandParameterParser));
        }

        /// <summary>
        /// Méthode responsable de traiter les commandes entrées par l'utilisateur sur la console
        /// </summary>
        /// <param name="argsCommands">Liste des commandes à traiter</param>
        /// <returns>Command</returns>
        public Command ParseCommand(string[] argsCommands)
        {
            // Vérifier est-ce que le premier argument est la commande 'PLACE'
            Command command;
            if (!Enum.TryParse(argsCommands[0], true, out command))
                throw new ArgumentException("Command not in the right format. Please try again using the correct format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT");
            return command;
        }

        /// <summary>
        /// Méthode responsable d'extraire les paramètres inclus dans les commandes
        /// </summary>
        /// <param name="parameters">Liste des commandes à traiter</param>
        /// <returns>PlaceCommandParameter</returns>
        public IPlaceCommandParameter ParseCommandParameter(string[] parameters)
        {
            return _placeCommandParameterParser.ParseParameters(parameters);
        }
    }
}
