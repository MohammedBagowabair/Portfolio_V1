using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivteClassMember
{
    public class Cl1
    {
        public int id { get; set; }
        public string name { get; set; }

        private int Salary;

        public Cl1()
        {
            
        }
        public Cl1(int id,string name)
        {
            this.id = id;
            this.name = name;
        }

    }
    public class cl2:Cl1
    {

        public void Show()
        {
            Console.WriteLine(id+name);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Cl1 cl1 = new Cl1(55,"hello");
            cl2 cl2 = new cl2();
            cl2.Show();
        }
    }
}
