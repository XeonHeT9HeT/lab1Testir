using NUnit.Framework;
using Moq;
using TestLab1Sort;
using MySortingProject;
using System;

namespace MySortingProject.Tests
{
    [TestFixture]
    public class SorterTests
    {
        private Mock<IShuffler> _mockShuffler;
        private Sorter _sorter;

        [SetUp]
        public void Setup()
        {
            _mockShuffler = new Mock<IShuffler>();
            _sorter = new Sorter(_mockShuffler.Object);
        }

        [Test]
        public void BogoSort_SortsArrayCorrectly()
        {
            int[] input = { 5, 3, 8, 1, 2 };
            int[] expected = { 1, 2, 3, 5, 8 };

            _mockShuffler.Setup(s => s.Shuffle(It.IsAny<int[]>()))
                         .Callback<int[]>(a => {
                             Array.Sort(a);
                         });

            int[] result = _sorter.Sort(input);

            Assert.AreEqual(expected, result);
            _mockShuffler.Verify(s => s.Shuffle(It.IsAny<int[]>()), Times.AtLeastOnce);
        }

        [Test]
        public void BogoSort_HandlesAlreadySortedArray()
        {
            int[] input = { 1, 2, 3, 4, 5 };
            int[] expected = { 1, 2, 3, 4, 5 };

            int[] result = _sorter.Sort(input);

            Assert.AreEqual(expected, result);
            _mockShuffler.Verify(s => s.Shuffle(It.IsAny<int[]>()), Times.Never);
        }

        [Test]
        public void BogoSort_HandlesReverseSortedArray()
        {
            int[] input = { 5, 4, 3, 2, 1 };
            int[] expected = { 1, 2, 3, 4, 5 };

            _mockShuffler.Setup(s => s.Shuffle(It.IsAny<int[]>()))
                         .Callback<int[]>(a => {
                             Array.Sort(a);
                         });

            int[] result = _sorter.Sort(input);

            Assert.AreEqual(expected, result);
            _mockShuffler.Verify(s => s.Shuffle(It.IsAny<int[]>()), Times.AtLeastOnce);
        }

        [Test]
        public void BogoSort_HandlesEmptyArray()
        {
            int[] input = { };
            int[] expected = { };

            int[] result = _sorter.Sort(input);

            Assert.AreEqual(expected, result);
            _mockShuffler.Verify(s => s.Shuffle(It.IsAny<int[]>()), Times.Never);
        }

        [Test]
        public void BogoSort_HandlesSingleElementArray()
        {
            int[] input = { 42 };
            int[] expected = { 42 };

            int[] result = _sorter.Sort(input);

            Assert.AreEqual(expected, result);
            _mockShuffler.Verify(s => s.Shuffle(It.IsAny<int[]>()), Times.Never);
        }

        [Test]
        public void BogoSort_HandlesArrayWithDuplicates()
        {
            int[] input = { 3, 1, 2, 3, 1 };
            int[] expected = { 1, 1, 2, 3, 3 };

            _mockShuffler.Setup(s => s.Shuffle(It.IsAny<int[]>()))
                         .Callback<int[]>(a => {
                             Array.Sort(a);
                         });

            int[] result = _sorter.Sort(input);

            Assert.AreEqual(expected, result);
            _mockShuffler.Verify(s => s.Shuffle(It.IsAny<int[]>()), Times.AtLeastOnce);
        }

        [Test]
        public void BogoSort_HandlesNegativeNumbers()
        {
            int[] input = { -1, -3, 2, 0, -5 };
            int[] expected = { -5, -3, -1, 0, 2 };

            _mockShuffler.Setup(s => s.Shuffle(It.IsAny<int[]>()))
                         .Callback<int[]>(a => {
                             Array.Sort(a);
                         });

            int[] result = _sorter.Sort(input);

            Assert.AreEqual(expected, result);
            _mockShuffler.Verify(s => s.Shuffle(It.IsAny<int[]>()), Times.AtLeastOnce);
        }
    }
}
