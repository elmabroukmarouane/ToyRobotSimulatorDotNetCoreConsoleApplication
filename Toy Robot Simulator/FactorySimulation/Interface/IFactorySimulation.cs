using Business.Service.RobotBehaviour.Interface;
using System;
using System.Collections.Generic;
using System.Text;

// Interface to delete we don't need it anymore because I wanted to create a new Factory in the Main program but I thought that make the class static 
// is more simple to exploit
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
