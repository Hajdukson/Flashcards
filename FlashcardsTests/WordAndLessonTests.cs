using System;
using System.Collections.Generic;
using Flashcards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlashcardsTests
{
    [TestClass]
    public class WordAndLessonTests
    {
        [TestMethod]
        public void CheckIfLessonNameIsEmpty()
        {
            //arange
            var lesson = new Lesson("");
            var expected = false;

            //act
            var actual = lesson.IsValid;

            //arrange
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void CheckIfLessonNameIsWhitespace()
        {
            //arange
            var lesson = new Lesson(" ");
            var expected = false;

            //act
            var actual = lesson.IsValid;

            //arrange
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void CheckIfLessonNameIsWatermark()
        {
            //arange
            var lesson = new Lesson("name the lesson");
            var expected = false;

            //act
            var actual = lesson.IsValid;

            //arrange
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CheckIfLessonIsOk()
        {
            //arange
            var lesson = new Lesson("lesson1");
            var expected = true;

            //act
            var actual = lesson.IsValid;

            //arrange
            Assert.AreEqual(actual, expected);
        }
    }
}
