using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DiceProject.Tests
{
    [TestClass()]
    public class PlayerTests

    {[TestMethod]
        public void PlayerNameNotAlphaNumeric()
        {
            //Arrange
            Player player = new Player();
            player.PlayerName = "Player$$";
            string expected = null;
            string expectedMessage = "Name can only contain letters and numbers.";

            //Act
            var actual = player.PlayerName;
            var actualMessage = player.ValidationMessage;

            //Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actualMessage, expectedMessage);   
        }

        [TestMethod]
        public void PlayerNameTooShort()
        {
            //Arrange
            Player player = new Player();
            player.PlayerName = "Pl";
            string expected = null;
            string expectedMessage = "Name cannot be less than 3 characters.";

            //Act
            var actual = player.PlayerName;
            var actualMessage = player.ValidationMessage;

            //Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actualMessage, expectedMessage);
        }

        [TestMethod]
        public void PlayerNameTooLong()
        {
            //Arrange
            Player player = new Player();
            player.PlayerName = "12345678901234";
            string expected = null;
            string expectedMessage = "Name cannot be longer than 12 characters.";

            //Act
            var actual = player.PlayerName;
            var actualMessage = player.ValidationMessage;

            //Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actualMessage, expectedMessage);
        }

        [TestMethod()]
        public void GetPlayerNameTestParam()
        {
            //Arrange
            Player player = new Player("Derek");
            var expected = "Derek";

            //Act
            var actual = player.PlayerName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetPlayerNameTest()
        {
            //Arrange
            Player player = new Player();
            player.PlayerName = "Derek";
            var expected = "Derek";

            //Act

            var actual = player.PlayerName;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}


