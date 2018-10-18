using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_day3;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Tasks();

            //Console.WriteLine("1 " + t.DoubleToBinaryString(255.255));
            //Console.WriteLine("2 " + t.DoubleToBinaryString(-255.255));
            //Console.WriteLine("3 " + t.DoubleToBinaryString(4294967295.0));
            Console.WriteLine("4 " + t.DoubleToBinaryString(double.NaN));
            //Console.WriteLine("5 " + t.DoubleToBinaryString(double.MaxValue));
            //Console.WriteLine("6 " + t.DoubleToBinaryString(1.0));

            int t1 = t.EucklidNOD(99, 1803, 256);

            Console.WriteLine(t1);

            Console.ReadKey();
        }
    }
}
