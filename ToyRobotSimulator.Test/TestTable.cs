using Business.Service.Table.Class;
using Business.Service.Table.Interface;
using Infrastructure.Classes.Robot;
using Infrastructure.Classes.Table;
using Infrastructure.Interfaces.Robot;
using Infrastructure.Interfaces.Table;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ToyRobotSimulator.Test
{
    [TestClass]
    public class TestTable
    {
        // Arrange
        private readonly ITable _table;
        protected readonly ITableService _tableService;
        public IPosition position;

        public TestTable()
        {
            _table = new Table(new Dimension());
            position = new Position(new Point(6, 6));
            _tableService = new TableService(_table);
        }

        /// <summary>
        /// Test Essayer de mettre le robot en dehors de la table
        /// </summary>
        [TestMethod]
        public void TestInvalidTablePosition()
        {
            // act
            var result = _tableService.IsWithinTable(position);

            // assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Test une position valide
        /// </summary>
        [TestMethod]
        public void TestValidTablePosition()
        {
            // arrange
            position.Point.X = 1;
            position.Point.Y = 4;

            // act
            var result = _tableService.IsWithinTable(position);

            // assert
            Assert.IsTrue(result);
        }
    }
}
