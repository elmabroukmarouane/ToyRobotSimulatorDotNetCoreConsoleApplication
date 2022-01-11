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
        // Si on veut vérifier est-ce qu'on aura des colisions entres les robots, il faut injecter la liste de tous les robots
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
                        // Pour vérifier est-ce qu'il aura une colision avec les robots, il faut faire comme suit :
                        // var countDown = 0; c'est le nombre des directions possible qu'un robot peut emprunter
                        // while(_robotService.HasColision(newPosition, robots) && countDown < 4) tant qu'il y un robot sur la direction à emprunter et dans la position voulue, on va le tourner à gauche
                        // {
                        //      _robotService.ToLeft();
                        //      countDown++;
                        // }
                        // if(countDown > 0 && countDown < 4) Ici, si jamais il n'a pas tourner 360°, alors il a trouvé une direction qui est vide pour se déplacer sinon il sera encercler des robots, et donc il ne pourra plus bouger
                        // {
                        //      _robotService.SetRobot(position: newPosition);
                        // }
                        _robotService.SetRobot(position: newPosition); // A supprimer s'il y en a plusieurs robots sur table
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
