

using NUnit.Framework;
using SnakesAndLadders.Logic.Game;
using SnakesAndLadders.Models;

namespace SnakeAndLadderTest
{
    internal class WhenTheyMoveTheirToken : TestForSnakeAndLadder
    {

        /// <summary>
        /// Dado que el juegador obtiene 4 en el dado.
        /// </summary>
        protected override void Given()
        {
            Dice.SetValuesAllow(4);
            Game = new Game(Players, new Board(10, 10), Dice);
            Game.StartGame();
        }

        [Test]
        public void ThenTheTokenShoulMoveFourSpaces()
        {
            var playerToken = Game.GetPlayerToken(Players[0]);
            var tokenBeforeMove = playerToken.Position;
            var diceValue = Game.RollDice();
            var playerTokenPostMove = Game.MovePlayer(Players[0], Game.RollDice());
            Assert.AreEqual(tokenBeforeMove + diceValue, playerTokenPostMove.Position);
        }


    }
}