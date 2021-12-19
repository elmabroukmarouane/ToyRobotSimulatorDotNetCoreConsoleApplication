using Business.Service.Robot.Interface;
using Infrastructure.Classes.Robot;
using Infrastructure.Enums.Robot;
using Infrastructure.Interfaces.Robot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Service.Robot.Class
{
    /// <summary>
    /// C'est la classe du service robot de simuation
    /// </summary>
    public class RobotService : IRobotService
    {
        protected IRobot _robot;

        public RobotService(IRobot robot)
        {
            _robot = robot ?? throw new ArgumentNullException(nameof(robot));
        }

        /// <summary>
        /// Retourne la prochaine position selon la direction
        /// </summary>
        /// <returns>Position</returns>
        public IPosition GetNextPosition()
        {
            var newPosition = new Position(new Point(_robot.Position.Point.X, _robot.Position.Point.Y));
            switch (_robot.Direction)
            {
                case Direction.North:
                    newPosition.Point.Y += 1;
                    break;
                case Direction.East:
                    newPosition.Point.X += 1;
                    break;
                case Direction.South:
                    newPosition.Point.Y -= 1;
                    break;
                case Direction.West:
                    newPosition.Point.X -= 1;
                    break;
            }
            return newPosition;
        }

        /// <summary>
        /// Retourne l'objet Robot
        /// </summary>
        /// <returns>Position</returns>
        public IRobot GetRobot()
        {
            return _robot;
        }

        /// <summary>
        /// Déplacer le Robot
        /// </summary>
        /// <param name="position">Position du Robot</param>
        /// <param name="direction">Direction du Robot</param>
        /// <returns>void</returns>
        public void Place(IPosition position, Direction direction)
        {
            _robot.Position = position ?? throw new ArgumentNullException(nameof(position));
            _robot.Direction = direction;
        }

        /// <summary>
        /// Modifier les attributs de l'objet Robot
        /// </summary>
        /// <returns>Position</returns>
        public void SetRobot(IPosition position = null, Direction? direction = null)
        {
            _robot.Position = position ?? _robot.Position;
            _robot.Direction = direction ?? _robot.Direction;
        }

        /// <summary>
        /// affecter un nouveau robot
        /// </summary>
        /// <returns>Position</returns>
        public void SetRobotObject(IRobot robot)
        {
            if (robot.Position == null) _robot = new Infrastructure.Classes.Robot.Robot();
            else SetRobot(robot.Position, robot.Direction);
        }

        /// <summary>
        /// Aller à gauche
        /// </summary>
        /// <returns>void</returns>
        public void ToLeft()
        {
            Turn(-1);
        }

        /// <summary>
        /// Aller à droite
        /// </summary>
        /// <returns>void</returns>
        public void ToRight()
        {
            Turn(1);
        }

        /// <summary>
        /// Tourner le robot à gauche ou à droite selon sa direction 
        /// </summary>
        /// <param name="position">Position du Robot</param>
        /// <param name="direction">Direction du Robot</param>
        /// <returns>void</returns>
        public void Turn(int MoveTurnNumber)
        {
            var directions = (Direction[])Enum.GetValues(typeof(Direction));
            Direction newDirection;
            if ((_robot.Direction + MoveTurnNumber) < 0)
                newDirection = directions[^1];
            else
            {
                var index = ((int)(_robot.Direction + MoveTurnNumber)) % directions.Length;
                newDirection = directions[index];
            }
            _robot.Direction = newDirection;
        }
    }
}
