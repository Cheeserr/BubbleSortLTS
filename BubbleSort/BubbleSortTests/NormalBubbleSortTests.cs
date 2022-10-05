using BubbleSortApp;

namespace BubbleSortTests
{
    public class Tests
    {
        // Lewis is handsome
        // Nathan is handsome
        // Tudor is ugly


        private int[] array = { 5, 2, 3, 8, 12 };
        private int[] arrayNeg = { -5, -2, -3, -8, -12 };
        private int[] array2 = {};
        private int[] array3 = Array.Empty<int>();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenArrayIsPassedThrough_BubbleSort2_ReturnsOrderedListInAscendingOrder()
        {
            int[] result = Program.BubbleSort2(array);
            Assert.That(result[0], Is.EqualTo(2));
            Assert.That(result[1], Is.EqualTo(3));
            Assert.That(result[2], Is.EqualTo(5));
            Assert.That(result[3], Is.EqualTo(8));
            Assert.That(result[4], Is.EqualTo(12));
        }
        [Test]
        public void WhenArrayIsEmpty_BubbleSort2_ReturnsEmptyArray()
        {
            Assert.That(() => Program.BubbleSort2(array2), Is.EqualTo(array3));
        }

        [Test]
        public void WhenArrayContainsNegativeNumbers_BubbleSort2_ReturnsOrderedListInAscendingOrder()
        {
            int[] result = Program.BubbleSort2(arrayNeg);
            Assert.That(result[0], Is.EqualTo(-12));
            Assert.That(result[1], Is.EqualTo(-8));
            Assert.That(result[2], Is.EqualTo(-5));
            Assert.That(result[3], Is.EqualTo(-3));
            Assert.That(result[4], Is.EqualTo(-2));
            
        }
    }
}