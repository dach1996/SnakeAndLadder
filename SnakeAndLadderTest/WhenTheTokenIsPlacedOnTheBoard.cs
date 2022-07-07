using NUnit.Framework;
using SnakesAndLadders.Logic.Game;
using SnakesAndLadders.Models;

namespace SnakeAndLadderTest
{
    public class WhenTheTokenIsPlacedOnTheBoard : TestForSnakeAndLadder
    {
        /// <summary>
        /// Dado el Juego Iniciado
        /// </summary>
        protected override void Given()
        {
            Dice.SetValuesAllow(3);
            Game = new Game(Players, new Board(10, 10), Dice);
            Game.StartGame();
        }
        /// <summary>
        /// La instanciación de los objectos player, game y dice se realizan en la clase 'TestForSnakeAndLadder'
        /// </summary>
        [Test]
        public void ThenTokenIsOnSquareOne()
        {
            var player = Players[0];
            var playerToken = Game.GetPlayerToken(player);
            Assert.AreEqual(1, playerToken.Position);
        }
    }
}