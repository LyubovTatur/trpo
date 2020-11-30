using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {

        delegate int Operation(int x, int y);
        delegate T myDrlrgate<T>(int val1, string val2, double val3, T myval);
        static T MyDelFunc<T>(int val1, string val2, double val3, T myval)
        {
            Console.WriteLine("вызвана MyDelFunc");
            return myval;
        }
        static string MyFunc<T>(T deleg)
        {
            return "вызвана MyFunc";
        }

        static void Main(string[] args)
        {
            myDrlrgate<int> op = MyDelFunc; 
            Console.WriteLine(  MyFunc<int>(op(3, "gfd", 4.2, 5)));         //1
            Operation operation = (x, y) => x + y;
            Console.WriteLine(operation(10, 20));                           //2
            Console.WriteLine(MyFunc<int>(operation(23, 55)));              //3
            Func<int, string, double, int, int> f = op.Invoke;
            Console.WriteLine(MyFunc<int>(f(3, "gfd", 4.2, 5)));            //4
            Console.ReadLine();

        }




    }
}