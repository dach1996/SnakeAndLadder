using NUnit.Framework;
using SnakesAndLadders.Logic.Game;
using System.Collections.Generic;
using System.Linq;

namespace SnakeAndLadderTest
{
    internal class WhenThePlayerRollADie : TestForSnakeAndLadder
    {
        /// <summary>
        /// Dado el Juego Iniciado
        /// </summary>
        protected override void Given()
        {
            Dice.SetValuesAllow(1, 2, 3, 4, 5, 6);
            Game = new Game(Players, Dice);
            Game.StartGame();
        }

        [Test]
        public void ThenResultShouldBeBetweenOneToSix()
        {
            var listValues = new List<int>();
            for (int i = 0; i < 1000; i++)
                listValues.Add(Dice.Throw());

            var valuesAllow = new int[] { 1, 2, 3, 4, 5, 6 };
            var isTrue = listValues.All(t => valuesAllow.Any(y => y == t));
            Assert.IsTrue(isTrue);
        }
    }
}