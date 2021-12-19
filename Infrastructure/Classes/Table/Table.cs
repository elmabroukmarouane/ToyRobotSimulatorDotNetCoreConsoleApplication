using Infrastructure.Interfaces.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Classes.Table
{
    /// <summary>
    /// Classe de la table où il se déplace le Robot
    /// </summary>
    public class Table : ITable
    {
        public IDimension Dimension { get; set; }

        public Table(IDimension dimension)
        {
            Dimension = dimension;
        }
    }
}
