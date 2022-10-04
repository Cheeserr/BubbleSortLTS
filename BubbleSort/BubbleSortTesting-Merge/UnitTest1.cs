using BubbleSortApp;

namespace BubbleSortTesting_Merge
{
    public class ArrayUnion_Tasks
    {
        [Test]
        public void WhenGiven_NullArray_ThrowException()
        {
            int[] array = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => Program.ArrayUnion(null, null));
            Assert.Throws<ArgumentNullException>(() => Program.ArrayUnion(null, array));
            Assert.Throws<ArgumentNullException>(() => Program.ArrayUnion(array, null));
        }

        [Test]
        public void WhenGiven_EmptyArrays_Returns_EmptyArray()
        {
            int[] array1 = new int[0];
            int[] array2 = new int[0];
            int[] expected = new int[0];

            var result = Program.ArrayUnion(array1, array2);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void WhenGiven_SimpleArray_Returns_Expected()
        {
            int[] array1 = { 1, 2, 4 };
            int[] array2 = { 3, 5, 6 };
            int[] expected = { 1, 2, 3, 4, 5, 6 };

            var result = Program.ArrayUnion(array1, array2);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void WhenGiven_ArrayWithNegatives_Returns_Expected()
        {
            int[] array1 = { 1, -2, 4 };
            int[] array2 = { 3, 5, -6 };
            int[] expected = { -6, -2, 1, 3, 4, 5 };

            var result = Program.ArrayUnion(array1, array2);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}