using Business.Helper.Interfaces.ConsoleManager;
using Business.Service.Robot.Interface;
using Business.Service.RobotBehaviour.Interface;
using Business.Service.Table.Interface;
using Infrastructure.Enums.Robot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Service.RobotBehaviour.Class
{
    /// <summary>
    /// Cette interface est utilisée pour simuler le comportement du Robot
    /// </summary>
    public class RobotBehaviour : IRobotBehaviour
    {
        protected readonly IRobotService _robotService;
        protected readonly ITableService _tableService;
        protected readonly ICommandArgsParser _commandArgsParser;

        public RobotBehaviour(IRobotService robotService, ITableService tableService, ICommandArgsParser commandArgsParser)
        {
            _robotService = robotService ?? throw new ArgumentNullException(nameof(robotService));
            _tableService = tableService ?? throw new ArgumentNullException(nameof(tableService));
            _commandArgsParser = commandArgsParser ?? throw new ArgumentNullException(nameof(commandArgsParser));
        }

        /// <summary>
        /// Méthode pour renvoyer la position et la direction actuelle du Robot
        /// </summary>
        /// <returns>string</returns>
        public string GetReport()
        {
            return string.Format("Output: {0},{1},{2}", _robotService.GetRobot().Position.Point.X,
                _robotService.GetRobot().Position.Point.Y, _robotService.GetRobot().Direction.ToString().ToUpper());
        }

        /// <summary>
        /// Méthode pour traiter les commandes entrées par l'utilisateur
        /// </summary>
        /// <param name="input">Liste des commandes à traiter</param>
        /// <returns>string</returns>
        public string ProcessCommand(string[] input)
        {
            var command = _commandArgsParser.ParseCommand(input);
            if (command != Command.Place && _robotService.GetRobot().Position == null) return string.Empty;

            switch (command)
            {
                case Command.Place:
                    var placeCommandParameter = _commandArgsParser.ParseCommandParameter(input);
                    if (_tableService.IsWithinTable(placeCommandParameter.Position))
                        _robotService.Place(placeCommandParameter.Position, placeCommandParameter.Direction);
                    break;
                case Command.Move:
                    var newPosition = _robotService.GetNextPosition();
                    if (_tableService.IsWithinTable(newPosition))
                        _robotService.SetRobot(position: newPosition);
                    break;
                case Command.Left:
                    _robotService.ToLeft();
                    break;
                case Command.Right:
                    _robotService.ToRight();
                    break;
                case Command.Report:
                    return GetReport();
            }
            return string.Empty;
        }
    }
}
