using Infrastructure.Enums.Robot;
using Infrastructure.Interfaces.Robot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Service.Robot.Interface
{
    /// <summary>
    /// C'est l'interface du service robot de simuation
    /// </summary>
    public interface IRobotService
    {
        /// <summary>
        /// Retourne l'objet Robot
        /// </summary>
        /// <returns>Position</returns>
        IRobot GetRobot();

        /// <summary>
        /// Modifier les attributs de l'objet Robot
        /// </summary>
        /// <returns>Position</returns>
        void SetRobot(IPosition position = null, Direction? direction = null);

        /// <summary>
        /// affecter un nouveau robot
        /// </summary>
        /// <returns>Position</returns>
        void SetRobotObject(IRobot robot);

        /// <summary>
        /// Retourne la prochaine position selon la direction
        /// </summary>
        /// <returns>Position</returns>
        IPosition GetNextPosition();

        /// <summary>
        /// Déplacer le Robot
        /// </summary>
        /// <param name="position">Position du Robot</param>
        /// <param name="direction">Direction du Robot</param>
        /// <returns>void</returns>
        void Place(IPosition position, Direction direction);

        /// <summary>
        /// Aller à gauche
        /// </summary>
        /// <returns>void</returns>
        void ToLeft();

        /// <summary>
        /// Aller à droite
        /// </summary>
        /// <returns>void</returns>
        void ToRight();

        /// <summary>
        /// Tourner le robot à gauche ou à droite selon sa direction 
        /// </summary>
        /// <param name="position">Position du Robot</param>
        /// <param name="direction">Direction du Robot</param>
        /// <returns>void</returns>  
        void Turn(int MoveTurnNumber);
    }
}
