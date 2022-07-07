using NUnit.Framework;
using SnakesAndLadders.Logic.Game;
using SnakesAndLadders.Models;

namespace SnakeAndLadderTest
{
    public class WhenTheTokenIsMovedThreeSpaces : TestForSnakeAndLadder
    {
        /// <summary>
        /// Cuando el Token está en la casilla 1
        /// </summary>
        protected override void Given()
        {
            Dice.SetValuesAllow(3);
            Game = new Game(Players, new Board(10, 10), Dice);
            Game.StartGame();
        }

        [Test]
        public void ThenTokenIsOnSquareFour()
        {
            var diceValue = Dice.Throw();
            var playerToken = Game.MovePlayer(Players[0], diceValue);
            Assert.AreEqual(4, playerToken.Position);
        }

        [Test]
        public void ThenTokenIsOnSquareEight()
        {
            _ = Game.MovePlayer(Players[0], Dice.Throw());
            Dice.SetValuesAllow(4);
            var playerToken = Game.MovePlayer(Players[0], Dice.Throw());
            Assert.AreEqual(8, playerToken.Position);
        }

    }
}