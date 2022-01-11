using Infrastructure.Enums.Robot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Robot
{
    /// <summary>
    /// C'est l'interface du robot de simuation
    /// </summary>
    public interface IRobot
    {
        Guid RobotNumber { get; set; }
        Direction Direction { get; set; }
        IPosition Position { get; set; }
    }
}
