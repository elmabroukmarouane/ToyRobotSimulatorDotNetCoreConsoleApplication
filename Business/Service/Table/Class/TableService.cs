using Business.Service.Table.Interface;
using Infrastructure.Interfaces.Robot;
using Infrastructure.Interfaces.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Service.Table.Class
{
    /// <summary>
    /// C'est la classe du service table
    /// </summary>
    public class TableService : ITableService
    {
        protected readonly ITable _table;

        public TableService(ITable table)
        {
            _table = table ?? throw new ArgumentNullException(nameof(table));
        }

        /// <summary>
        /// Méthode permet d'identifier est-ce que le robot est encore sur la table ou non
        /// </summary>
        /// <param name="position">Position du Robot</param>
        /// <returns>bool</returns>
        public bool IsWithinTable(IPosition position)
        {
            return position.Point.X < _table.Dimension.Columns && position.Point.X >= 0 &&
                      position.Point.Y < _table.Dimension.Rows && position.Point.Y >= 0;
        }
    }
}
