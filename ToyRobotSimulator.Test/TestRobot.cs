using Business.Service.Robot.Class;
using Business.Service.Robot.Interface;
using Infrastructure.Classes.Robot;
using Infrastructure.Enums.Robot;
using Infrastructure.Interfaces.Robot;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace RobotSimulator.Test
{
    [TestClass]
    public class TestRobot
    {
        // Arrange
        protected readonly IRobot _robot;
        protected readonly IRobotService _robotService;

        public TestRobot()
        {
            _robot = new Robot { Direction = Direction.West, Position = new Position(new Point(2, 2)) };
            _robotService = new RobotService(_robot);
        }

        /// <summary>
        /// Test robot tourne à gauche
        /// </summary>
        [TestMethod]
        public void TestValidRobotTurnLeft()
        {
            // act
            _robotService.ToLeft();

            // assert
            Assert.AreEqual(Direction.South, _robotService.GetRobot().Direction);
        }

        /// <summary>
        /// Test robot tourne à droite
        /// </summary>
        [TestMethod]
        public void TestValidRobotTurnRight()
        {
            // arrange
            _robotService.SetRobot(direction: Direction.East);

            // act
            _robotService.ToRight();

            // assert
            Assert.AreEqual(Direction.South, _robotService.GetRobot().Direction);
        }

        /// <summary>
        /// Test robot se déplace
        /// </summary>
        [TestMethod]
        public void TestValidRobotMove()
        {
            // arrange
            _robotService.SetRobot(direction: Direction.East);

            // act
            var nextPosition = _robotService.GetNextPosition();

            // assert
            Assert.AreEqual(3, nextPosition.Point.X);
            Assert.AreEqual(2, nextPosition.Point.Y);
        }

        /// <summary>
        /// Test robot renseigner la position et la direction
        /// </summary>
        [TestMethod]
        public void TestValidRobotPositionAndDirection()
        {
            // arrange
            var position = new Position(new Point(3, 3));
            _robotService.SetRobotObject(new Robot());

            // act
            _robotService.Place(position, Direction.North);

            // assert
            Assert.AreEqual(3, _robotService.GetRobot().Position.Point.X);
            Assert.AreEqual(3, _robotService.GetRobot().Position.Point.Y);
            Assert.AreEqual(Direction.North, _robotService.GetRobot().Direction);
        }

        /// <summary>
        /// Test Pas de colision entre robots
        /// </summary>
        [TestMethod]
        public void TestNoColisionWithOtherRobots()
        {
            // arrange
            _robotService.SetRobot(direction: Direction.East);
            var robot2 = new Robot();
            var position2 = new Position(new Point(4, 4));
            var robotService2 = new RobotService(robot2);
            robotService2.Place(position2, Direction.North);
            var robot3 = new Robot();
            var position3 = new Position(new Point(2, 4));
            var robotService3 = new RobotService(robot3);
            robotService3.Place(position3, Direction.East);
            var robots = new List<IRobot>
            {
                _robot,
                robot2,
                robot3
            };

            // act
            var nextPosition = _robotService.GetNextPosition();

            // assert
            Assert.AreEqual(false, _robotService.HasColision(nextPosition, robots));
        }

        /// <summary>
        /// Test colision entre robots
        /// </summary>
        [TestMethod]
        public void TestColisionWithOtherRobots()
        {
            // arrange
            _robotService.SetRobot(direction: Direction.East);
            var robot2 = new Robot();
            var position2 = new Position(new Point(4, 4));
            var robotService2 = new RobotService(robot2);
            robotService2.Place(position2, Direction.North);
            var robot3 = new Robot();
            var position3 = new Position(new Point(3, 2));
            var robotService3 = new RobotService(robot3);
            robotService3.Place(position3, Direction.East);
            var robots = new List<IRobot>
            {
                _robot,
                robot2,
                robot3
            };

            // act
            var nextPosition = _robotService.GetNextPosition();

            // assert
            Assert.AreEqual(true, _robotService.HasColision(nextPosition, robots));
        }
    }
}
