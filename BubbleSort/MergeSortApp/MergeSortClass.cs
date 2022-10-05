namespace MergeSortApp
{
    public class MergeSortClass
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 2, 3, 8, 12 };
            MergeSort(array);
        }

        public static int[] MergeSort(int[] array)
        {
            if (array.Length == 1) return array;

            int midpoint = array.Length / 2;

            int[] leftSide = new int[midpoint] ;
            int[] rightSide = new int[array.Length - midpoint];

            for(int i = 0; i < midpoint; i++)
            {
                leftSide[i] = array[i];
            }
            for (int i = 0; i < rightSide.Length; i++)
            {
                rightSide[i] = array[midpoint + i];
            }

            return Merge(MergeSort(leftSide), MergeSort(rightSide));

        }

        public static int[] Merge(int[] array1, int[] array2)
        {
            int[] output = new int[array1.Length + array2.Length];

            int size1 = 0;
            int size2 = 0;

            for(int i = 0; i < output.Length; i++)
            {
                if (size1 < array1.Length && size2 < array2.Length)
                {
                    if (array1[size1] < array2[size2])
                    {
                        output[i] = array1[size1];
                        size1++;
                    }
                    else
                    {
                        output[i] = array2[size2];
                        size2++;
                    }
                }
                else
                {
                    if (size1 < array1.Length)
                    {
                        output[i] = array1[size1];
                        size1++;
                    }
                    else
                    {
                        output[i] = array2[size2];
                        size2++;
                    }
                }
            }


            return output;
        }
    }
}