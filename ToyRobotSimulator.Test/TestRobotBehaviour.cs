using Business.Helper.Classes.ConsoleManager;
using Business.Helper.Interfaces.ConsoleManager;
using Business.Service.Robot.Class;
using Business.Service.Robot.Interface;
using Business.Service.RobotBehaviour.Class;
using Business.Service.RobotBehaviour.Interface;
using Business.Service.Table.Class;
using Business.Service.Table.Interface;
using Infrastructure.Classes.Robot;
using Infrastructure.Classes.Table;
using Infrastructure.Enums.Robot;
using Infrastructure.Interfaces.Robot;
using Infrastructure.Interfaces.Table;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ToyRobot_simulator.Test
{
    [TestClass]
    public class TestRobotBehaviour
    {
        // Arrange
        private readonly IPlaceCommandParameterParser _placeCommandParameterParser;
        private readonly ITable _table;
        private readonly ITableService _tableService;
        private readonly ICommandArgsParser _commandArgsParser;
        private readonly IRobot _robot;
        private readonly IRobotService _robotService;
        private readonly IRobotBehaviour _simulator;

        public TestRobotBehaviour()
        {
            _placeCommandParameterParser = new PlaceCommandParameterParser();
            _table = new Table(new Dimension());
            _tableService = new TableService(_table);
            _commandArgsParser = new CommandArgsParser(_placeCommandParameterParser);
            _robot = new Robot();
            _robotService = new RobotService(_robot);
            _simulator = new RobotBehaviour(_robotService, _tableService, _commandArgsParser);
        }

        /// <summary>
        /// Test Example A
        /// </summary>
        [TestMethod]
        public void TestExampleA()
        {
            // act
            _simulator.ProcessCommand("PLACE 0,0,NORTH".Split(' '));
            _simulator.ProcessCommand("MOVE".Split(' '));

            // assert
            Assert.AreEqual("Output: 0,1,NORTH", _simulator.GetReport());
        }

        /// <summary>
        /// Test Example B
        /// </summary>
        [TestMethod]
        public void TestExampleB()
        {
            // act
            _simulator.ProcessCommand("PLACE 0,0,NORTH".Split(' '));
            _simulator.ProcessCommand("LEFT".Split(' '));

            // assert
            Assert.AreEqual("Output: 0,0,WEST", _simulator.GetReport());
        }

        /// <summary>
        /// Test Example C
        /// </summary>
        [TestMethod]
        public void TestExampleC()
        {
            // act
            _simulator.ProcessCommand("PLACE 1,2,EAST".Split(' '));
            _simulator.ProcessCommand("MOVE".Split(' '));
            _simulator.ProcessCommand("MOVE".Split(' '));
            _simulator.ProcessCommand("LEFT".Split(' '));
            _simulator.ProcessCommand("MOVE".Split(' '));

            // assert
            Assert.AreEqual("Output: 3,3,NORTH", _simulator.GetReport());
        }

        /// <summary>
        /// Test commande 'PLACE' valide
        /// </summary>
        [TestMethod]
        public void TestValidBehaviourPlace()
        {
            // act
            _simulator.ProcessCommand("PLACE 1,4,EAST".Split(' '));

            // assert
            Assert.AreEqual(1, _robot.Position.Point.X);
            Assert.AreEqual(4, _robot.Position.Point.Y);
            Assert.AreEqual(Direction.East, _robot.Direction);
        }

        /// <summary>
        /// Test commande 'PLACE' invalide
        /// </summary>
        [TestMethod]
        public void TestInvalidBehaviourPlace()
        {
            // act
            _simulator.ProcessCommand("PLACE 9,7,EAST".Split(' '));

            // assert
            Assert.IsNull(_robot.Position);
        }

        /// <summary>
        /// Test commande 'MOVE' valide
        /// </summary>
        [TestMethod]
        public void TestValidBehaviourMove()
        {
            // act
            _simulator.ProcessCommand("PLACE 3,2,SOUTH".Split(' '));
            _simulator.ProcessCommand("MOVE".Split(' '));

            // assert
            Assert.AreEqual("Output: 3,1,SOUTH", _simulator.GetReport());
        }

        /// <summary>
        /// Test commande 'MOVE' invalide
        /// </summary>
        [TestMethod]
        public void TestInvalidBehaviourMove()
        {
            // act
            _simulator.ProcessCommand("PLACE 2,2,NORTH".Split(' '));
            _simulator.ProcessCommand("MOVE".Split(' '));
            _simulator.ProcessCommand("MOVE".Split(' '));
            // Si le robot est sorti de la table alors la commande est ignorée
            _simulator.ProcessCommand("MOVE".Split(' '));

            // assert
            Assert.AreEqual("Output: 2,4,NORTH", _simulator.GetReport());
        }

        /// <summary>
        /// Test commande 'MOVE' valide dans la table et tester la sortie du rapport
        /// </summary>
        [TestMethod]
        public void TestValidBehaviourReport()
        {
            // act
            _simulator.ProcessCommand("PLACE 3,3,WEST".Split(' '));
            _simulator.ProcessCommand("MOVE".Split(' '));
            _simulator.ProcessCommand("MOVE".Split(' '));
            _simulator.ProcessCommand("LEFT".Split(' '));
            _simulator.ProcessCommand("MOVE".Split(' '));
            var output = _simulator.ProcessCommand("REPORT".Split(' '));

            // assert
            Assert.AreEqual("Output: 1,2,SOUTH", output);
        }
    }
}
