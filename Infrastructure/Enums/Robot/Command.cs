using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Enums.Robot
{
    /// <summary>
    /// Enum qui inclue la liste de toutes les commandes possible pour lancer la simulation du Robot
    /// </summary>
    public enum Command
    {
        Place,
        Move,
        Left,
        Right,
        Report
    }
}
