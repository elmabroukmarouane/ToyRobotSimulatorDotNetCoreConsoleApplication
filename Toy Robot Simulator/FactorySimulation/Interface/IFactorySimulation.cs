using Business.Service.RobotBehaviour.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Toy_Robot_Simulator.FactorySimulation.Interface
{
    /// <summary>
    /// C'est l'interface Factory qui instancie le simulateur
    /// </summary>
    public interface IFactorySimulation
    {
        /// <summary>
        /// C'est méthode qui instancie le simulateur
        /// </summary>
        /// <returns>RobotBehaviour</returns>
        IRobotBehaviour GetSimulator();
    }
}
