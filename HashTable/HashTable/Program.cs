using System.Collections;

partial class Program
{
    static void Main(string[] args)
    {
        CustomHashtable myHashTable = new CustomHashtable(50);
        myHashTable.Set("grapes", 10000);
        Console.WriteLine(myHashTable.Get("grapes"));

        myHashTable.Set("apples", 9);
        Console.WriteLine(myHashTable.Get("apples"));

    }
}


// Create My HashTable
//Get
//Set
//HashFuncation

// [["Apple",5000],["Bananna",56]]
class CustomHashtable
{
    private int size;
    private List<KeyValuePair<string, int>>[] data;

    public CustomHashtable(int size)
    {
        this.size = size;
       this.data = new List<KeyValuePair<string, int>>[size];
    }

    public void Set(string key, int value)
    {
        int address = Hash(key);
        if (data[address] == null) {
            data[address]=new List<KeyValuePair<string, int>>();
        }

        for (int i = 0; i < data[address].Count; i++) 
        {
            if (data[address][i].Key == key)
            {
                data[address][i] = new KeyValuePair<string, int>(key, value);
                return;
            }
        }

        data[address].Add(new KeyValuePair<string, int>(key, value));

    }

    public int? Get(string key) 
    {
        int address = Hash(key);
        var currentBucket = data[address];
        if (currentBucket != null) 
        {
            for (int i = 0; i < data[address].Count; i++)
            {
                if (data[address][i].Key == key)
                {
                    return data[address][i].Value;
                }
            }
        }
        return null;

    }

    private int Hash(string key)
    {
        int hash = 0;
        for (int i = 0; i < key.Length; i++)
        {
            hash = (hash + key[i] * i) % data.Length;
        }
        return hash;
    }
}