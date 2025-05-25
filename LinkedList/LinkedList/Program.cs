using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

partial class Program
{
    static void Main(string[] args)
    {
        MyLinlkedLsit myLinlkedLsit = new MyLinlkedLsit();
        ////Append
        //myLinlkedLsit.Append(5);
        //myLinlkedLsit.Append(10);
        //myLinlkedLsit.Append(15);
        //myLinlkedLsit.Append(20);
        //myLinlkedLsit.Display();
        ////Preapend
        //myLinlkedLsit.Prepend(1);
        //myLinlkedLsit.Display();
        //Console.WriteLine(myLinlkedLsit.Length());
        ////Insert
        //myLinlkedLsit.Insert(2, 99);
        //myLinlkedLsit.Insert(55, 100);
        //myLinlkedLsit.Display();
        //Console.WriteLine(myLinlkedLsit.Length());
        ////Remove
        //myLinlkedLsit.Remove(3);
        //myLinlkedLsit.Display();
        //Console.WriteLine(myLinlkedLsit.Length());


        myLinlkedLsit.Append(1);
        myLinlkedLsit.Append(5);
        myLinlkedLsit.Append(10);
        myLinlkedLsit.Append(99);
        myLinlkedLsit.Append(15);
        myLinlkedLsit.Append(20);
        myLinlkedLsit.Append(30);
        //Remove
        myLinlkedLsit.Remove(0);
        myLinlkedLsit.Display();
        Console.WriteLine(myLinlkedLsit.Length());

    }
}

//1 -> 5 -> 10 -> 99 -> 15 -> 20 -> 30 -> null
public class MyLinlkedLsit
{
    private Node head;
    public int length = 0;
    public void Append(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node curentNode = head;
            while (curentNode.Next != null)
            {
                curentNode = curentNode.Next;
            }
            curentNode.Next = newNode;
        }
        length++;
    }
    public void Prepend(int data)
    {
        Node newNode = new Node(data);
        Node curentNode = head;
        if (curentNode == null)
        {
            head = newNode;
        }
        else
        {
            newNode.Next = curentNode;
            head = newNode;
        }
        length++;

    }
    public int Length()
    {
        return length;
    }
    public void Insert(int index, int value)
    {
        if (index < 0)
        {
            Console.WriteLine("Index out of bounds");
            return;
        }
        if (index >= length)
        {
            Append(value);
            return;
        }
        if (index == 0)
        {
            Prepend(value);
            return;
        }

        Node newNode = new Node(value);
        Node current = head;

        for (int i = 0; i < index - 1; i++)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        current.Next = newNode;
        length++;
    }
    public void Remove(int index)
    {
        if (index < 0 || index >= length)
        {
            Console.WriteLine("Index Out Of Bounds");
            return;
        }

        if (index == 0)
        {
            head = head.Next;
        }
        else
        {
            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            current.Next = current.Next?.Next;
        }

        length--;
    }
    public void Display()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write($"{current.Data} -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }

}

public class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}