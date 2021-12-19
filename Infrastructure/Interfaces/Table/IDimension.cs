using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Table
{
    /// <summary>
    /// Interface de la dimension de la table où il se déplace le Robot
    /// </summary>
    public interface IDimension
    {
        int Rows { get; }
        int Columns { get; }
    }
}
