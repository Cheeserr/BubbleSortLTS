using System.Diagnostics;
using System.Globalization;

namespace BubbleSortApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                int[] array = { 1, 3, 5, 8, 10, 15, 20, 7, 17, 2, 6, 16, 30 };
                array = BubbleSort(array);
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedTicks);

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            for (int i = 0; i < 1000000; i++)
            {
                int[] array = { 1, 3, 5, 8, 10, 15, 20, 7, 17, 2, 6, 16, 30 };
                array = BubbleSort2(array);
            }
            stopwatch2.Stop();
            Console.WriteLine(stopwatch2.ElapsedTicks);


            Stopwatch stopwatch3 = new Stopwatch();
            stopwatch3.Start();
            for (int i = 0; i < 1000000; i++)
            {
                int[] array = { 1, 3, 5, 8, 10, 15, 20, 7, 17, 2, 6, 16, 30 };
                array = BubbleSort3(array);
            }
            stopwatch3.Stop();
            Console.WriteLine(stopwatch3.ElapsedTicks);
            //Console.WriteLine(ArrayUnion(array, array2).ToString());
        }

        
        public static int[] BubbleSort(int[] unsortedList)
        {
            for (int i = 0; i < unsortedList.Length - 1; i++)
            {
                for (int j = 0; j < unsortedList.Length - (1 + i); j++)
                {
                    if (unsortedList[j] > unsortedList[j + 1])
                    {
                        Swap(ref unsortedList[j], ref unsortedList[j + 1]);
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

        public static int[] BubbleSort3(int[] unList)
        {
            int listSize = unList.Length;
            while (listSize > 1)
            {
                int newListSize = 0;
                for (int i = 1; i <= listSize - 1; i++)
                {
                    if (unList[i - 1] > unList[i])
                    {
                        Swap(ref unList[i - 1], ref unList[i]);
                        newListSize = i;
                    }
                }
                listSize = newListSize;
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
            if (array1 is null || array2 is null) throw new ArgumentNullException();

            var finalArray = new List<int>();
            var linkedList = new LinkedList<int>();


            foreach(int number in array1)
            {
                if (!finalArray.Contains(number)) finalArray.Add(number);
            }
            foreach (int number in array2)
            {
                if (!finalArray.Contains(number)) finalArray.Add(number);
            }
            


            return BubbleSort2(finalArray.ToArray());
            //dick
        }
    }
}