using Business.Helper.Classes.ConsoleManager;
using Business.Helper.Interfaces.ConsoleManager;
using Infrastructure.Enums.Robot;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ToyRobotSimulator.Test
{
    [TestClass]
    public class TestCommandManager
    {
        // Arrange
        private readonly IPlaceCommandParameterParser _placeCommandParameterParser;
        private readonly ICommandArgsParser _commandArgsParser;

        public TestCommandManager()
        {
            _placeCommandParameterParser = new PlaceCommandParameterParser();
            _commandArgsParser = new CommandArgsParser(_placeCommandParameterParser);
        }

        /// <summary>
        /// Test commande 'PLACE' valide
        /// </summary>
        [TestMethod]
        public void TestValidPlaceCommand()
        {
            // arrange
            string[] rawInput = "PLACE".Split(' ');

            // act
            var command = _commandArgsParser.ParseCommand(rawInput);

            // assert
            Assert.AreEqual(Command.Place, command);
        }

        /// <summary>
        /// Test commande 'PLACE' invalide
        /// </summary>
        [TestMethod]
        public void TestInvalidPlaceCommand()
        {
            // arrange
            string[] rawInput = "PLACEROBOT".Split(' ');

            // act and assert
            var exception = Assert.ThrowsException<ArgumentException>(delegate { _commandArgsParser.ParseCommand(rawInput); });
            Assert.AreEqual(exception.Message, "Command not in the right format. Please try again using the correct format: PLACE X,Y,Direction|MOVE|LEFT|RIGHT|REPORT");
        }

        /// <summary>
        /// Test commande 'PLACE' valide avec paramètres
        /// </summary>
        [TestMethod]
        public void TestValidPlaceCommandAndParams()
        {
            // arrange
            string[] rawInput = "PLACE 4,3,WEST".Split(' ');

            // act
            var placeCommandParameter = _commandArgsParser.ParseCommandParameter(rawInput);

            // assert
            Assert.AreEqual(4, placeCommandParameter.Position.Point.X);
            Assert.AreEqual(3, placeCommandParameter.Position.Point.Y);
            Assert.AreEqual(Direction.West, placeCommandParameter.Direction);
        }

        /// <summary>
        /// Test commande 'PLACE' avec des paramètres manquants
        /// </summary>
        [TestMethod]
        public void TestInvalidPlaceCommandAndParams()
        {
            // arrange
            string[] rawInput = "PLACE 3,1".Split(' ');

            // act and assert
            var exception = Assert.ThrowsException<ArgumentException>(delegate
            { var placeCommandParameter = _commandArgsParser.ParseCommandParameter(rawInput); });
            Assert.AreEqual(exception.Message, "Your 'PLACE' Command is incomplete. Please make sure that you're entering the right format (PLACE X,Y,Direction)");
        }

        /// <summary>
        /// Test commande 'PLACE' avec une direction invalide
        /// </summary>
        [TestMethod]
        public void TestInvalidPlaceDirection()
        {
            // arrange
            string[] rawInput = "PLACE 2,4,WESTCOAST".Split(' ');

            // act and assert
            var exception = Assert.ThrowsException<ArgumentException>(delegate { _placeCommandParameterParser.ParseParameters(rawInput); });
            Assert.AreEqual(exception.Message, "Your 'PLACE' Command has an invalid direction. Please select and enter one of the following directions: NORTH|EAST|SOUTH|WEST");
        }

        /// <summary>
        /// Test commande 'PLACE' avec un paramètre mal formulé
        /// </summary>
        [TestMethod]
        public void TestInvalidPlaceParamsFormat()
        {
            // arrange
            string[] rawInput = "PLACE 3,3,SOUTH,2".Split(' ');

            // act and assert
            var exception = Assert.ThrowsException<ArgumentException>(delegate { _placeCommandParameterParser.ParseParameters(rawInput); });
            Assert.AreEqual(exception.Message, "Your 'PLACE' Command is incomplete. Please make sure that you're entering the right format (PLACE X,Y,Direction)");
        }
    }
}
