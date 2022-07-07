using NUnit.Framework;
using SnakesAndLadders.Logic;
using SnakesAndLadders.Logic.Game;
using SnakesAndLadders.Logic.Implementation.Dice;
using SnakesAndLadders.Logic.Interface;
using SnakesAndLadders.Models;
using SnakesAndLadders.Models.Game;
using System.Collections.Generic;

namespace SnakeAndLadderTest
{
    public abstract class TestForSnakeAndLadder
    {
        protected IList<Player> Players;
        protected Game Game;
        protected DiceMock Dice;

        [SetUp]
        protected void Setup()
        {
            Players = new List<Player>() { new Player("Player 1") };
            Dice = new DiceMock();
            Given();
        }

        protected abstract void Given();

        [TearDown]
        protected virtual void TearDown()
        => Setup();


    }
}