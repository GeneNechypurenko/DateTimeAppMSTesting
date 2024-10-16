using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DateTimeApp;

namespace DateTimeApp.Tests
{
    [TestClass]
    public class DateTimeTests
    {
        [TestMethod]
        public void DateTimeAppTest1()
        {
            // Arrange
            int day = 1, month = 1, year = 2024, hour = 0, minute = 0;
            DateTime expected = new DateTime(year, month, day, hour, minute, 0);

            // Act
            DateTime actual = new DateTime(year, month, day, hour, minute, 0);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DateTimeAppTest2()
        {
            // Arrange
            int year = 2024, month = 2, day = 30;

            // Act & Assert
            try
            {
                _ = new DateTime(year, month, day, 12, 0, 0);
                Assert.Fail("Expected ArgumentOutOfRangeException not thrown.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(ex.Message, "Day");
            }
        }

        [TestMethod]
        public void DateTimeAppTest3()
        {
            // Arrange
            int year = 2024, month = 13, day = 10;

            // Act & Assert
            try
            {
                _ = new DateTime(year, month, day, 12, 0, 0);
                Assert.Fail("Expected ArgumentOutOfRangeException not thrown.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(ex.Message, "Month");
            }
        }


        [TestMethod]
        public void DateTimeAppTest4()
        {
            // Arrange
            string input = "5";
            int min = 1, max = 10;
            Func<string> mockInput = () => input;

            // Act
            int result = Program.ReadInt("", min, max, mockInput);

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void DateTimeAppTest5()
        {
            // Arrange
            string input = "abc";
            int min = 0, max = 5;
            Func<string> mockInput = () => input;

            // Act & Assert
            try
            {
                Program.ReadInt("", min, max, mockInput);
                Assert.Fail("Expected FormatException not thrown.");
            }
            catch (FormatException ex)
            {
                StringAssert.Contains(ex.Message, "неверный формат");
            }
        }

        [TestMethod]
        public void DateTimeAppTest6()
        {
            // Arrange
            int hour = 10, maxHour = 23;

            // Act
            bool isValid = hour >= 0 && hour <= maxHour;

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void DateTimeAppTest7()
        {
            // Arrange
            int hour = -1, maxHour = 23;

            // Act
            bool isValid = hour >= 0 && hour <= maxHour;

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void DateTimeAppTest8()
        {
            // Arrange
            string input = "40";
            int min = 1, max = 31;
            Func<string> mockInput = () => input;

            // Act & Assert
            try
            {
                Program.ReadInt("День:", min, max, mockInput);
                Assert.Fail("Expected ArgumentOutOfRangeException not thrown.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(ex.Message, "между");
            }
        }

        [TestMethod]
        public void DateTimeAppTest9()
        {
            // Arrange
            string input = "1";
            int min = 1, max = 31;
            Func<string> mockInput = () => input;

            // Act
            int result = Program.ReadInt("День:", min, max, mockInput);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void DateTimeAppTest10()
        {
            // Arrange
            string input = "31";
            int min = 1, max = 31;
            Func<string> mockInput = () => input;

            // Act
            int result = Program.ReadInt("День:", min, max, mockInput);

            // Assert
            Assert.AreEqual(31, result);
        }
    }
}
