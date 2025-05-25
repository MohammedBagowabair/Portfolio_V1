partial class Progaram
{
    static void Main(string[] args)
    {
        int[] input = new int[] { 1, 2, 3, 4 };
        string myDictonary= FirstRecuuringChar(input);
        Console.WriteLine(myDictonary);
    }

    //[2,5,1,2,3,5,1,2,4]
    //Output:2

    //[2,1,1,2]
    //output:1

    //[1,2,3,4]
    //null

    public static string FirstRecuuringChar(int[] array)
    {
        int[] charactersArray;
        Dictionary<int,int?> checkingDictionary = new Dictionary<int,int?>();

        // Check The Input
        if (array != null)
        {
            charactersArray = array;
        }
        else
        {
            return null;
        }

        foreach (var i in charactersArray)
        {
            if (checkingDictionary.ContainsKey(i))
            {
                return i.ToString();
            }
            else
            {
                checkingDictionary.Add(i, null);
            }
        }



        return null;
    }

    //public static int? FirstRecurringChar(int[] array)
    //{
    //    if (array == null || array.Length == 0)
    //        return null;

    //    for (int i = 1; i < array.Length; i++) 
    //    {
    //        for (int j = 0; j < i; j++) 
    //        {
    //            if (array[i] == array[j])
    //            {
    //                return array[j]; 
    //            }
    //        }
    //    }

    //    return null;
    //}
}



