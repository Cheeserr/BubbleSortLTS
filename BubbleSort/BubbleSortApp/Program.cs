using System.Data;
using System.Diagnostics;

namespace BubbleSortApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 6, 5, 9, 3, 2, -5 };
            ProfileSortsIter(10);
        }

        public static int[] BubbleSort(int[] unsortedList)
        {
            for (int i = 0; i < unsortedList.Length - 1; i++)
            {
                for (int j = 0; j < unsortedList.Length - (1 + i); j++)
                {
                    if (unsortedList[j] > unsortedList[j + 1])
                    {
                        int temp = unsortedList[j + 1];
                        unsortedList[j + 1] = unsortedList[j];
                        unsortedList[j] = temp;
                    }
                }
            }
            return unsortedList;
        }

        public static int[] BubbleSort2(int[] unList)
        {
            bool swapped = true;
            int listSize = unList.Length - 1;
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < listSize; i++)
                {
                    if (unList[i] > unList[i + 1])
                    {
                        Swap(ref unList[i], ref unList[i + 1]);
                        swapped = true;
                    }
                }
                listSize--;
            }
            return unList;
        }

        public static void Swap(ref int number1, ref int number2)
        {
            int temp = number1;
            number1 = number2;
            number2 = temp;
        }

        public static int[] ArrayUnion(int[] array1, int[] array2)
        {
            if (array1 is null || array2 is null) throw new ArgumentNullException();

            var finalArray = new List<int>();

            foreach (int number in array1)
            {
                if (!finalArray.Contains(number)) finalArray.Add(number);
            }
            foreach (int number in array2)
            {
                if (!finalArray.Contains(number)) finalArray.Add(number);
            }

            return BubbleSort2(finalArray.ToArray());
        }

        // 
        public static int[] MergeAndSort(int[] array1, int[] array2, bool keepDuplicates)
        {
            if (keepDuplicates)
                return ArrayUnionLewis(array1, array2);
            return ArrayUnion(array1, array2);
        }

        public static int[] ArrayUnionLewis(int[] array1, int[] array2)
        {
            if (array1 is null || array2 is null)
                throw new ArgumentNullException();

            var finalArray = new List<int>(array1.Length + array2.Length);
            finalArray.AddRange(array1);
            finalArray.AddRange(array2);
            return BubbleSort2(finalArray.ToArray());
        }

        public static int[] GenerateRandomDataSet(int count)
        {
            Random randNum = new Random();
            return Enumerable.Repeat(0, count)
                .Select(i => randNum.Next(0, int.MaxValue)).ToArray();
        }

        private static long ProfileMergeSortFunc(int[] dataSet1, int[] dataSet2, Func<int[], int[], int[]> sorter)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            sorter.Invoke(dataSet1, dataSet2);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        private static long ProfileSortFunc(int dataSetSize, Func<int[], int[]> sorter)
        {
            var dataSet = GenerateRandomDataSet(dataSetSize);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            sorter.Invoke(dataSet);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        private static void ProfileSortsIter(int count)
        {
            int dataSetSize = 30000;

            var dataSet1 = GenerateRandomDataSet(dataSetSize);
            var dataSet2 = GenerateRandomDataSet(dataSetSize);

            for (int i = 1; i <= count; ++i)
            {
                Console.WriteLine($"[{i}] (Tudor)  BubbleSort: {ProfileSortFunc(dataSetSize, BubbleSort)} ms");
                Console.WriteLine($"[{i}] (Serg)   BubbleSort2: {ProfileSortFunc(dataSetSize, BubbleSort2)} ms");
                Console.WriteLine($"[{i}] MergeSort: {ProfileSortFunc(dataSetSize, mergeSort)} ms");
                Console.WriteLine($"[{i}] ArrayUnion: {ProfileMergeSortFunc(dataSet1, dataSet2, ArrayUnion)} ms");
                Console.WriteLine($"[{i}] ArrayUnionLewis: {ProfileMergeSortFunc(dataSet1, dataSet2, ArrayUnionLewis)} ms");
                Console.WriteLine();
            }
        }

        public static int[] mergeSort(int[] array)
        {
            int[] left;
            int[] right;
            int[] result = new int[array.Length];
            //As this is a recursive algorithm, we need to have a base case to 
            //avoid an infinite recursion and therfore a stackoverflow
            if (array.Length <= 1)
                return array;
            // The exact midpoint of our array  
            int midPoint = array.Length / 2;
            //Will represent our 'left' array
            left = new int[midPoint];

            //if array has an even number of elements, the left and right array will have the same number of 
            //elements
            if (array.Length % 2 == 0)
                right = new int[midPoint];
            //if array has an odd number of elements, the right array will have one more element than left
            else
                right = new int[midPoint + 1];
            //populate left array
            for (int i = 0; i < midPoint; i++)
                left[i] = array[i];
            //populate right array   
            int x = 0;
            //We start our index from the midpoint, as we have already populated the left array from 0 to midpont
            for (int i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }
            //Recursively sort the left array
            left = mergeSort(left);
            //Recursively sort the right array
            right = mergeSort(right);
            //Merge our two sorted arrays
            result = merge(left, right);
            return result;
        }

        public static int[] merge(int[] left, int[] right)
        {
            int resultLength = right.Length + left.Length;
            int[] result = new int[resultLength];
            //
            int indexLeft = 0, indexRight = 0, indexResult = 0;
            //while either array still has an element
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                //if both arrays have elements  
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    //If item on left array is less than item on right array, add that item to the result array 
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    // else the item in the right array wll be added to the results array
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                //if only the left array still has elements, add all its items to the results array
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                //if only the right array still has elements, add all its items to the results array
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }

    }
}
