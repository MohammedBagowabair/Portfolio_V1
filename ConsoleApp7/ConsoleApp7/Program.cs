//partial class Progaram
//{
//    static void Main(string[] args)
//    {
//        int[] input = new int[] { 2, 5, 8,5, 3, 5,2 };


//        int? myDictonary = FirstRecuuringChar(input);
//        Console.WriteLine(myDictonary);
//    }


//    public static int? FirstRecuuringChar(int[] array)
//    {
//        int[] charactersArray;
//        List<int> indexces;
//        int smaller=0;
//        int counter = 1;


//        // Check The Input
//        if (array != null)
//        {
//            charactersArray = array;
//            indexces= new List<int>();
//        }
//        else
//        {
//            return null;
//        }

//        for(int i = 0; i < charactersArray.Length-1; i++)
//        {
//            counter += i;
//            for (int j =i+1; j < charactersArray.Length; j++)
//            {
//                if (charactersArray[i]== charactersArray[j] && !indexces.Contains(charactersArray[i]))
//                {
//                    indexces.Add(counter);
//                }
//                else
//                {
//                    counter++;
//                }

//            }
//            counter = 1;
//        }


//        for (int i = 0; i < indexces.Count - 1; i++)
//        {
//            smaller = indexces[0];
//            for (int j = 0; j < indexces.Count; j++)
//            {
//                if (indexces[j] < smaller)
//                {
//                    smaller = indexces[j];
//                }
//            }
//        }

//        return charactersArray[smaller];
//    }

//}

using System;

partial class Program
{
    static void Main(string[] args)
    {
        int[] input = new int[] { 2,0,8,6,5,4,3,5,2,66};
        int? firstRecurring = FirstRecurringChar(input);
        Console.WriteLine(firstRecurring.HasValue ? firstRecurring.Value.ToString() : "No recurring character");
    }

    public static int? FirstRecurringChar(int[] array)
    {
        if (array == null || array.Length == 0)
            return null;

        for (int i = 1; i < array.Length; i++) // Start from the 2nd element
        {
            for (int j = 0; j < i; j++) // Compare with all previous elements
            {
                if (array[i] == array[j])
                {
                    return array[j]; // Return the first recurring in order
                }
            }
        }

        return null;
    }
    //2, 5,5, 2, 8, 5, 3, 5, 20
}