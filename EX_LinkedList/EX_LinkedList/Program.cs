using System;

class Program
{
    static void Main(string[] args)
    {
        MyLinkedList myLinkedList = new MyLinkedList();
        myLinkedList.Add(5);
        myLinkedList.Add(10);
        myLinkedList.Add(15);
        myLinkedList.Add(20);
        myLinkedList.Display();
    }
}

public class MyLinkedList
{
    private Node head;

    public void Add(int value)
    {
        Node newNode = new Node(value);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = newNode;
        }
    }

    public void Display()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write($"{current.Data} -> ");
            current = current.next;
        }
        Console.WriteLine("null");
    }
}

public class Node
{
    public int Data;
    public Node? next;

    public Node(int value)
    {
        Data = value;
        next = null;
    }
}
