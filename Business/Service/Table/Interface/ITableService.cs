using Infrastructure.Interfaces.Robot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Service.Table.Interface
{
    public interface ITableService
    {
        /// <summary>
        /// Méthode permet d'identifier est-ce que le robot est encore sur la table ou non
        /// </summary>
        /// <param name="position">Position du Robot</param>
        /// <returns>bool</returns>
        bool IsWithinTable(IPosition position);
    }
}
