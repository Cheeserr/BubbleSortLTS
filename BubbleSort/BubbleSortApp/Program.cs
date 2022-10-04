using System.Globalization;

namespace BubbleSortApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 6, 5, 9, 3, 2, -5 };
        }

        /*
        public static void BubbleSort(int[] unsortedList)
        {
            int temp;
            for (int i = 0; i < unsortedList.Length - 1; i++)
            {
                for (int j = 0; j < unsortedList.Length - (1 + i); j++)
                {
                    if (unsortedList[j] > unsortedList[j + 1])
                    {
                        temp = unsortedList[j + 1];
                        unsortedList[j + 1] = unsortedList[j];
                        unsortedList[j] = temp;
                    }
                }
            }
        }
        */
        public static int[] BubbleSort2(int[] unList)
        {
            bool swapped = true;
            int listSize = unList.Length - 1;
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < listSize; i++) {
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

        public static void Swap(ref int number1,ref int number2)
        {
            int temp = number1;
            number1 = number2;
            number2 = temp;
        }


        public static int[] ArrayUnion(int[] array1, int[] array2)
        {
            if (array1 is null || array2 is null) throw new Exception("Arrays cannot be null");

            var finalArray = new List<int>();



            foreach(int number in array1)
            {
                if (!finalArray.Contains(number)) finalArray.Add(number);
            }
            foreach (int number in array2)
            {
                if (!finalArray.Contains(number)) finalArray.Add(number);
            }
            


            return BubbleSort2(finalArray.ToArray());
        }
    }
}