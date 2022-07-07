using NUnit.Framework;
using SnakesAndLadders.Logic.Game;
using SnakesAndLadders.Models;
using SnakesAndLadders.Models.Enums;

namespace SnakeAndLadderTest
{
    internal class WhenTokenIsMovedFourSpaces : TestForSnakeAndLadder
    {
        /// <summary>
        /// Dado que el token esté en la posición 97
        /// </summary>
        protected override void Given()
        {
            Dice.SetValuesAllow(4);
            Game = new Game(Players, new Board(10, 10), Dice);
            Game.StartGame();
            _ = Game.MovePlayer(Players[0], 96);
        }

        [Test]
        public void ThenTokenIsOnSquareNinetySevenAndPlayerIsNotWinner()
        {
            var diceValue = Game.RollDice();
            var playerToken = Game.MovePlayer(Players[0], diceValue);
            Assert.AreEqual(97, playerToken.Position);
            Assert.AreEqual(TokenState.Playing, playerToken.TokenState);
        }
    }
}