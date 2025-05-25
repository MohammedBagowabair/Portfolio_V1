// See https://aka.ms/new-console-template for more information

partial class  Program
{
    static void Main(string[] args)
    {
        Reverse("Mohammed");
    }

    static void Reverse(string str)
    {
        char[] charArray = str.ToCharArray();
        Console.WriteLine(charArray);
    }
}
