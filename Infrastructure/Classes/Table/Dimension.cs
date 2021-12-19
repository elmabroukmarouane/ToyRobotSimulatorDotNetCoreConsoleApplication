using Infrastructure.Interfaces.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Classes.Table
{
    /// <summary>
    /// Classe de la dimension de la table où il se déplace le Robot
    /// </summary>
    public class Dimension : IDimension
    {
        public int Rows { get; private set; } = 5;

        public int Columns { get; private set; } = 5;
    }
}
