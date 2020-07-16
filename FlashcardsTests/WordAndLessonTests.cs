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

            //assert
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

            //assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void CheckIfLessonNameIsWatermark()
        {
            //arrange
            var lesson = new Lesson("Name the lesson".ToLower());
            var expected = false;

            //act
            var actual = lesson.IsValid;

            //assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CheckIfLessonIsOk()
        {
            //arrange
            var lesson = new Lesson("lesson1");
            var expected = true;

            //act
            var actual = lesson.IsValid;

            //assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void CheckIfLessonRepoIsFalse()
        {
            //arrange
            var lesson = new Lesson();
            var expected = false;

            //act
            var actual = true;
            var words = lesson.CheckIfWordRepoIsFalse();
            foreach (var word in words)
            {
                actual = word.IsValid;
            }

            //assert
            Assert.AreEqual(actual, expected);
        }
        public void CheckIfLessonRepoIsTrue()
        {
            //arrange
            var lesson = new Lesson("testLesson");
            var expected = true;

            //act
            var actual = false;
            var words = lesson.Words;
            foreach (var word in words)
            {
                actual = word.IsValid;
            }

            //assert
            Assert.AreEqual(actual, expected);
        }
    }
}
