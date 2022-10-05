using BubbleSortApp;
using MergeSortApp;

namespace BubbleSortTesting
{
    public class ArrayUnion_Tasks
    {
        [Test]
        public void WhenGiven_NullArray_ThrowException()
        {
            int[] array = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => MergeSortClass.Merge(null, null));
            Assert.Throws<ArgumentNullException>(() => MergeSortClass.Merge(null, array));
            Assert.Throws<ArgumentNullException>(() => MergeSortClass.Merge(array, null));
        }

        [Test]
        public void WhenGiven_EmptyArrays_Returns_EmptyArray()
        {
            int[] array1 = new int[0];
            int[] array2 = new int[0];
            int[] expected = new int[0];

            var result = MergeSortClass.Merge(array1, array2);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void WhenGiven_SimpleArray_Returns_Expected()
        {
            int[] array1 = { 1, 2, 4 };
            int[] array2 = { 3, 5, 6 };
            int[] expected = { 1, 2, 3, 4, 5, 6 };

            var result = MergeSortClass.Merge(array1, array2);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void WhenGiven_ArrayWithNegatives_Returns_Expected()
        {
            int[] array1 = { -2, 1 , 4 };
            int[] array2 = { -6, 3, 5 };
            int[] expected = { -6, -2, 1, 3, 4, 5 };

            var result = MergeSortClass.Merge(array1, array2);
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void GivenDifferentLengthArrays_Merge_ReturnsMergedArray()
        {
            int[] array1 = { 2, 3, 5, 8, 12 };
            int[] array2 = { 1, 3, 5 };
            int[] expected = { 1, 2, 3, 3, 5, 5, 8, 12 };
            Assert.That(MergeSortClass.Merge(array1, array2), Is.EqualTo(expected));
        }

        [Test]
        public void MergeSortSimpleTest()
        {
            int[] array = { 5, 2, 3, 8, 12 };
            int[] expected = { 2, 3, 5, 8, 12 };
            Assert.That(MergeSortClass.MergeSort(array), Is.EqualTo(expected));
        }

        [Test]
        public void GivenNegativeArray_MergeSort_ReturnMergeSortedArray()
        {
            int[] array = { -5, -2, -3, -8, -12 };
            int[] expected = { -12, -8, -5, -3, -2 };
            Assert.That(MergeSortClass.MergeSort(array), Is.EqualTo(expected));
        }
        
        [Test]
        public void GivenMixedArray_MergeSort_ReturnMergeSortedArray()
        {
            int[] array = { 5, -2, 3, -8, 12 };
            int[] expected = {-8, -2, 3, 5, 12};
            Assert.That(MergeSortClass.MergeSort(array), Is.EqualTo(expected));
        }
        [Test]
        public void GivenEmptyArray_MergeSort_ReturnMergeSortedArray()
        {
            int[] array = new int[0];
            int[] expected = new int[0];
            Assert.That(MergeSortClass.MergeSort(array), Is.EqualTo(expected));
        }
        [Test]
        public void WhenGivenNullArray_MergeSort_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => MergeSortClass.MergeSort(null));
        }
    }
}