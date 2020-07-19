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
            var actual = StringHandler.RetrivWordInDescription(word, note);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
