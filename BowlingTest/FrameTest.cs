using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bowling;

namespace BowlingTest
{
    [TestClass]
    public class FrameTest
    {

        [TestMethod]
        public void TestFrameScore()
        {
            Frame frame = new Frame(new Game(), 1);
            Assert.AreEqual(0, frame.Score);
            frame.roll(5);
            frame.roll(4);
            Assert.AreEqual(9, frame.Score);
        }

        [TestMethod]
        public void TestMaxRollNumber()
        {
            Frame frame = new Frame(new Game(), 1);
            frame.roll(4);
            frame.roll(4);
            try
            {
                frame.roll(1);
                Assert.Fail("Should not be able to roll more than 2 times per frame");
            }
            catch (Exception e) {
                Console.WriteLine("Expected error", e);
            }
        }

        [TestMethod]
        public void TestMaxPinsDown()
        {
            Frame frame = new Frame(new Game(), 1);
            try
            {
                frame.roll(Frame.MAX_PINS_ON_TRACK + 1);
                Assert.Fail("Should not be able to knock more than " + Frame.MAX_PINS_ON_TRACK + " pins down in one shot");
            }
            catch (Exception e) {
                Console.WriteLine("Expected error", e);
            }

            Frame frame2 = new Frame(new Game(), 1);
            frame2.roll(5);
            try
            {
                frame2.roll(Frame.MAX_PINS_ON_TRACK - 4);
                Assert.Fail("Should not be able to knock more than " + Frame.MAX_PINS_ON_TRACK + " pins in one frame");
            }
            catch (Exception e) {
                Console.WriteLine("Expected error", e);
            }
        }

        [TestMethod]
        public void TestCallBack()
        {
            Assert.IsNull(new Frame(new Game(), 1).roll(1));
            Assert.AreEqual(typeof(StrikeBonusCallBack), (new Frame(new Game(), 1).roll(Frame.MAX_PINS_ON_TRACK)).GetType());
            Frame frame = new Frame(new Game(), 1);
            frame.roll(2);
            Assert.AreEqual(typeof(SpareBonusCallBack), frame.roll(Frame.MAX_PINS_ON_TRACK - 2).GetType());
        }

        [TestMethod]
        public void TestIsDone()
        {
            //Two shots case
            Frame frame = new Frame(new Game(), 1);
            Assert.IsFalse(frame.IsDone());
            frame.roll(1);
            Assert.IsFalse(frame.IsDone());
            frame.roll(1);
            Assert.IsTrue(frame.IsDone());

            //Strike case
            Frame frame2 = new Frame(new Game(), 1);
            Assert.IsFalse(frame2.IsDone());
            frame2.roll(Frame.MAX_PINS_ON_TRACK);
            Assert.IsTrue(frame2.IsDone());
        }

        [TestMethod]
        public void TestStrike()
        {
            //Two shots case
            Frame frame = new Frame(new Game(), 1);
            Assert.IsFalse(frame.Strike);
            frame.roll(Frame.MAX_PINS_ON_TRACK);
            Assert.IsTrue(frame.Strike);

            //Strike case
            Frame frame2 = new Frame(new Game(), 1);
            frame2.roll(Frame.MAX_PINS_ON_TRACK - 1);
            Assert.IsFalse(frame2.Strike);
            frame2.roll(1);
            Assert.IsFalse(frame2.Strike);
        }

        [TestMethod]
        public void TestSpare()
        {
            //Two shots case
            Frame frame = new Frame(new Game(), 1);
            Assert.IsFalse(frame.Spare);
            frame.roll(Frame.MAX_PINS_ON_TRACK);
            Assert.IsFalse(frame.Spare);

            //Strike case
            Frame frame2 = new Frame(new Game(), 1);
            frame2.roll(Frame.MAX_PINS_ON_TRACK - 1);
            Assert.IsFalse(frame2.Spare);
            frame2.roll(1);
            Assert.IsTrue(frame2.Spare);
        }

    }
}
