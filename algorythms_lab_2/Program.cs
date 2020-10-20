using System;
using static System.Console;

namespace algorythms_lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Clear();
            WriteLine("Tap 1 or 2");
            WriteLine("1 - First part");
            WriteLine("2 - Second part");
            var output = new Output();
            var n = ReadKey().Key;
            switch (n)
            {
                case ConsoleKey.D1:
                    Clear();
                    output.FirstPath();
                    break;
                case ConsoleKey.D2:
                    Clear();
                    output.SecondPath();
                    break;
            }
            if (ReadKey().Key == ConsoleKey.Escape)
                Main(new string[] { });

            /*var t = new TxtStackExecutor();
            t.Append("input1_1.txt");
            //t.Append("input1.txt");
            var g = new TimeAnalizer();
            g.Actions += () => t.Append("input1.txt");
            g.Actions += () => t.Execute();
            g.Analyze();
            var asd = new StackCalculator("input2.txt");
            var asdd = asd.Execute();
            var s = new Stack<int>();
            s.Any();
            s.Push(1);
            s.Any();
            var a = s.Peek();
            s.Push(2);
            var s1 = new Stack<int>(s);
            s1.Pop();
            s.Push(3);
            s.Push(4);
            s.Push(5);
            s.Push(6);
            var b = s.Pop();
            Console.WriteLine(s);*/

        }
    }
}
