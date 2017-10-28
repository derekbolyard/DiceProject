using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace DiceProject.CommonTests
{
    [TestClass]
    public class DiceLogicTests
    {
        [TestMethod]
        public void FiveOfAKindTestTrue()
        {
            //Arrange
            List<int> rolls = new List<int>() { 1, 1, 1, 1, 1 };
            var expected = true;

            //Act
            var actual = DiceLogic.FiveOfAKind(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FiveOfAKindTestFalse()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 3, 4, 1, 2 };
            var expected = false;

            //Act
            var actual = DiceLogic.FiveOfAKind(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void FourOfAKindTestTrue()
        {
            //Arrange
            List<int> rolls = new List<int>() { 1, 1, 1, 1, 2 };
            var expected = true;

            //Act
            var actual = DiceLogic.FourOfAKind(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FourOfAKindTestFalse()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 3, 3, 3, 2 };
            var expected = false;

            //Act
            var actual = DiceLogic.FourOfAKind(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PairTestTrue()
        {
            //Arrange
            List<int> rolls = new List<int>() { 1, 1, 2, 3, 4 };
            var expected = true;

            //Act
            var actual = DiceLogic.Pair(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PairTestFalseTwoPair()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 3, 3, 5, 2 };
            var expected = false;

            //Act
            var actual = DiceLogic.Pair(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PairTestFalseFullHouse()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 5, 3, 3, 3 };
            var expected = false;

            //Act
            var actual = DiceLogic.Pair(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PairTestFalseThreeOfAKind()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 3, 3, 3, 2 };
            var expected = false;

            //Act
            var actual = DiceLogic.Pair(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PairTestFalse()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 4, 3, 1, 2 };
            var expected = false;

            //Act
            var actual = DiceLogic.Pair(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoPairTestTrue()
        {
            //Arrange
            List<int> rolls = new List<int>() { 1, 1, 2, 2, 4 };
            var expected = true;

            //Act
            var actual = DiceLogic.TwoPair(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoPairTestFalse()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 3, 3, 4, 2 };
            var expected = false;

            //Act
            var actual = DiceLogic.TwoPair(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullHouseTrue()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 5, 3, 3, 3 };
            var expected = true;

            //Act
            var actual = DiceLogic.FullHouse(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullHouseFalseTwoPair()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 5, 3, 3, 1 };
            var expected = false;

            //Act
            var actual = DiceLogic.FullHouse(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullHouseFalsePair()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 5, 3, 2, 1 };
            var expected = false;

            //Act
            var actual = DiceLogic.FullHouse(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullHouseFalseThreeOfAKind()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 4, 3, 3, 3 };
            var expected = false;

            //Act
            var actual = DiceLogic.FullHouse(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FiveHighStraightTrue()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 4, 3, 2, 1 };
            var expected = true;

            //Act
            var actual = DiceLogic.FiveHighStraight(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FiveHighStraightFalse()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 4, 3, 3, 1 };
            var expected = false;

            //Act
            var actual = DiceLogic.FiveHighStraight(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FiveHighStraightFalseSix()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 4, 3, 2, 6 };
            var expected = false;

            //Act
            var actual = DiceLogic.FiveHighStraight(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SixHighStraightTrue()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 4, 3, 2, 6 };
            var expected = true;

            //Act
            var actual = DiceLogic.SixHighStraight(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SixHighStraightFalse()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 4, 6, 3, 1 };
            var expected = false;

            //Act
            var actual = DiceLogic.SixHighStraight(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SixHighStraightFalsePair()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 4, 6, 3, 3 };
            var expected = false;

            //Act
            var actual = DiceLogic.SixHighStraight(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SixHighStraightFalseFive()
        {
            //Arrange
            List<int> rolls = new List<int>() { 5, 4, 3, 2, 1 };
            var expected = false;

            //Act
            var actual = DiceLogic.SixHighStraight(rolls);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
