using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Table
{
    /// <summary>
    /// Interface de la table où il se déplace le Robot
    /// </summary>
    public interface ITable
    {
        IDimension Dimension { get; set; }
    }
}
