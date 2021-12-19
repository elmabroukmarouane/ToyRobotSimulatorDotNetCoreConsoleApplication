using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Helper.Interfaces.ConsoleManager
{
    /// <summary>
    /// Interface pour vérifier les paramètres de la command 'PLACE'
    /// </summary>
    public interface IPlaceCommandParameterParser
    {
        /// <summary>
        /// Méthode responsable de vérifier la position initiale du robot and la direction dans laquelle il se dirige
        /// </summary>
        /// <param name="parameters">Liste des commandes à traiter</param>
        /// <returns>PlaceCommandParameter</returns>
        IPlaceCommandParameter ParseParameters(string[] parameters);
    }
}
