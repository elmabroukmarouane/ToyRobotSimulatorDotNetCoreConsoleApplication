using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Enums.Robot;

namespace Business.Helper.Interfaces.ConsoleManager
{
    /// <summary>
    /// Interface pour traiter les commandes entrées par l'utilisateur sur la console
    /// </summary>
    public interface ICommandArgsParser
    {
        /// <summary>
        /// Méthode responsable de traiter les commandes entrées par l'utilisateur sur la console
        /// </summary>
        /// <param name="argsCommands">Liste des commandes à traiter</param>
        /// <returns>Command</returns>
        Command ParseCommand(string[] argsCommands);

        /// <summary>
        /// Méthode responsable d'extraire les paramètres inclus dans les commandes
        /// </summary>
        /// <param name="parameters">Liste des commandes à traiter</param>
        /// <returns>PlaceCommandParameter</returns>
        IPlaceCommandParameter ParseCommandParameter(string[] parameters);
    }
}
