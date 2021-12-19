using Business.Service.RobotBehaviour.Interface;
using Business.Helper.Classes.ConsoleManager;
using Business.Service.Robot.Class;
using Business.Service.RobotBehaviour.Class;
using Infrastructure.Interfaces.Table;
using Business.Service.Table.Class;
using Infrastructure.Classes.Robot;
using Infrastructure.Classes.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Toy_Robot_Simulator.FactorySimulation.Class
{
    /// <summary>
    /// C'est la classe Factory qui instancie le simulateur
    /// </summary>
    public static class FactorySimulation
    {
        /// <summary>
        /// C'est méthode qui instancie le simulateur
        /// </summary>
        /// <returns>RobotBehaviour</returns>
        public static IRobotBehaviour GetSimulator()
        {
            var table = new Table(new Dimension());
            var tableService = new TableService(table);
            var placeCommandParameterParser = new PlaceCommandParameterParser();
            var commandArgsParser = new CommandArgsParser(placeCommandParameterParser);
            var robot = new Robot();
            var robotService = new RobotService(robot);
            return new RobotBehaviour(robotService, tableService, commandArgsParser); ;
        }
    }
}
