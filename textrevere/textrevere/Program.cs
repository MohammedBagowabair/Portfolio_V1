using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textrevere
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            string text = "Mohammed";
            Console.WriteLine(new string(text.Reverse().ToArray()));

            Console.ReadLine();
        }
    }
}
