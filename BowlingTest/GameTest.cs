using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bowling;

namespace BowlingTest
{
    [TestClass]
    public class GameTest
    {

        [TestMethod]
        public void TestGameScoreWithTwoShotsWhoseTotalIsLessThanTen()
        {
            Game game = new Game();
            game.roll(5);
            game.roll(4);
            Assert.AreEqual(9, game.score());
        }

        [TestMethod]
        public void TestGameScoreWithOneSpare()
        {
            Game game = new Game();
            game.roll(6);
            game.roll(Frame.MAX_PINS_ON_TRACK - 6);
            game.roll(3);
            Assert.AreEqual(16, game.score());
        }

        [TestMethod]
        public void TestGameScoreWithOneStrike()
        {
            Game game = new Game();
            game.roll(Frame.MAX_PINS_ON_TRACK);
            game.roll(5);
            game.roll(4);
            Assert.AreEqual(28, game.score());
        }

        [TestMethod]
        public void TestGameMaxScore()
        {
            Game game = new Game();
            for (int i = 1; i <= 12; i++)
            {
                game.roll(Frame.MAX_PINS_ON_TRACK);
            }
            Assert.IsTrue(game.Over);
            try
            {
                game.roll(1);
                Assert.Fail("Game is over");
            }
            catch (Exception e) {
                Console.WriteLine("Expected error", e);
            }
            
            Assert.AreEqual(300, game.score());
        }

        [TestMethod]
        public void TestGameIsOverAfter10Trous()
        {
            Game game = new Game();
            for (int i = 1; i <= 10; i++)
            {
                game.roll(2);
                game.roll(3);
            }
            Assert.AreEqual(50, game.score());
        }

        [TestMethod]
        public void TestGameIsOverFinishingWithStrike()
        {
            Game game = new Game();
            for (int i = 1; i <= 9; i++)
            {
                game.roll(2);
                game.roll(3);
            }
            game.roll(Frame.MAX_PINS_ON_TRACK);
            Assert.IsFalse(game.Over);
            game.roll(10);
            Assert.IsFalse(game.Over);
            game.roll(10);
            Assert.IsTrue(game.Over);

            Assert.AreEqual(75, game.score());
        }

        [TestMethod]
        public void TestGameIsOverFinishingWithSpare()
        {
            Game game = new Game();
            for (int i = 1; i <= 9; i++)
            {
                game.roll(2);
                game.roll(3);
            }
            game.roll(5);
            game.roll(Frame.MAX_PINS_ON_TRACK - 5);
            Assert.IsFalse(game.Over);
            game.roll(10);
            Assert.IsTrue(game.Over);

            Assert.AreEqual(65, game.score());
        }

        [TestMethod]
        public void TestSpecGame()
        {
            Game game = new Game();
            game.roll(1);
            game.roll(4);
            game.roll(4);
            game.roll(5);
            game.roll(6);
            game.roll(4);
            game.roll(5);
            game.roll(5);
            game.roll(10);
            game.roll(0);
            game.roll(1);
            game.roll(7);
            game.roll(3);
            game.roll(6);
            game.roll(4);
            game.roll(10);
            game.roll(2);
            game.roll(8);
            game.roll(6);
            Assert.AreEqual(133, game.score());
            Assert.IsTrue(game.Over);
        }
    }
}
