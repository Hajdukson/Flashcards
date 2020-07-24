using System;
using Flashcards.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlashcardsTests.Common
{
    [TestClass]
    public class StringHandlerTest
    {
        [TestMethod]
        public void CheckIfWordWasTaken()
        {
            //arrange
            var word = "mother";
            var note = "My mother is the best.";
            var expected = "My ______ is the best.";

            //act
            var actual = StringHandler.RetrivAndHideWordInDescription(word, note);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckIfWordWasTaken2()
        {
            //arrange
            var word = "mountain";
            var note = "The mountains are the highest thing on the earth.";
            var expected = "The ________s are the highest thing on the earth.";

            //act
            var actual = StringHandler.RetrivAndHideWordInDescription(word, note);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckIfWordWasTaken3()
        {
            //arrange
            var word = "Mountain";
            var note = "The mountains are the highest thing on earth.\n The highest mountain is Mount Everest";
            var expected = "The ________s are the highest thing on earth.\n The highest ________ is Mount Everest";

            //act
            var actual = StringHandler.RetrivAndHideWordInDescription(word, note);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
