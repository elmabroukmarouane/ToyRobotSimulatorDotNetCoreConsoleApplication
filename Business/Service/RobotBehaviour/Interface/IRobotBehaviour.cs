using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Service.RobotBehaviour.Interface
{
    /// <summary>
    /// Cette interface est utilisée pour simuler le comportement du Robot
    /// </summary>
    public interface IRobotBehaviour
    {
        /// <summary>
        /// Méthode pour renvoyer la position et la direction actuelle du Robot
        /// </summary>
        /// <returns>string</returns>
        string GetReport();

        /// <summary>
        /// Méthode pour traiter les commandes entrées par l'utilisateur
        /// </summary>
        /// <param name="input">Liste des commandes à traiter</param>
        /// <returns>string</returns>
        string ProcessCommand(string[] input);
    }
}
