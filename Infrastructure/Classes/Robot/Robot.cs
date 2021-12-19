using Infrastructure.Enums.Robot;
using Infrastructure.Interfaces.Robot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Classes.Robot
{
    /// <summary>
    /// C'est la classe du robot de simuation
    /// </summary>
    public class Robot : IRobot
    {
        public Direction Direction { get; set; }
        public IPosition Position { get; set; }
    }
}
