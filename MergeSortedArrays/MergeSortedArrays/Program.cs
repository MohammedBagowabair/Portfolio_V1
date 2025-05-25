partial class Program
{
    static void Main(string[] args)
    {
        // [0,3,4,31]  [4,6,30]
        //[0,3,4,4,6,30,31]
        //int[] array1 = { 0, 3, 4, 31 };
        //int[] array2 = { 4, 6, 30 };
        //Console.WriteLine(MergeSortedArrays(array1, array2));

        int[] array1 = { 0, 3, 4, 31 };
        int[] array2 = { 3, 4, 6, 30 };

        int[] mergedArray = MergeSortedArrays(array1, array2);
        Console.WriteLine(string.Join(", ", mergedArray));

    }

    static int[] MergeSortedArrays(int[] array1, int[] array2)
    {
        int i = 0;
        int j = 0;
        List<int> mergedArray = new List<int>();

        // Edge cases: If any array is empty
        if (array1.Length == 0)
            return array2;
        if (array2.Length == 0)
            return array1;

        // Merge using two pointers
        while (i < array1.Length && j < array2.Length)
        {
            if (array1[i] < array2[j])
            {
                mergedArray.Add(array1[i]);
                i++;
            }
            else
            {
                mergedArray.Add(array2[j]);
                j++;
            }
        }

        // Add remaining elements from array1
        while (i < array1.Length)
        {
            mergedArray.Add(array1[i]);
            i++;
        }

        // Add remaining elements from array2
        while (j < array2.Length)
        {
            mergedArray.Add(array2[j]);
            j++;
        }

        return mergedArray.ToArray();



        //1
        //static void MergeSortedArrays(int[] firstArray,int[] secondArray)
        //{
        //    int[] mergedArray= new int[firstArray.Length+secondArray.Length];

        //    Array.Copy(firstArray,mergedArray,firstArray.Length);
        //    Array.Copy(secondArray, 0, mergedArray, firstArray.Length, secondArray.Length); // Copy second array

        //    Array.Sort(mergedArray);

        //    foreach (var i in mergedArray)
        //    {
        //        Console.WriteLine(i);
        //    }
        //}

        //2
        //static int [] MergeSortedArrays(int[] firstArray, int[] secondArray)
        //{
        //    int[] mergedArray = new int[firstArray.Length + secondArray.Length];
        //    int count = 0;

        //    for (int i = 0; i < firstArray.Length; i++) {
        //        mergedArray[i]=firstArray[i];
        //        count++;
        //    }
        //    for (int i = 0; i < secondArray.Length; i++)
        //    {
        //        mergedArray[count] = secondArray[i];
        //        count++;
        //    }

        //    Array.Sort(mergedArray);
        //    foreach (int i in mergedArray)
        //    {
        //        Console.WriteLine(i);
        //    }
        //    return mergedArray;
        //}


        //3


    }
}