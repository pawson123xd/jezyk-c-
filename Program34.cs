using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp34
{
    class test
    {
        public int x { get; set; }
        public test(int x) {
            this.x = x;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            test test1=new test(23);
            Console.WriteLine(test1.x);
        }
    }
}
