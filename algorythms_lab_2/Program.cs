﻿using System;

namespace algorythms_lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Console.WriteLine(s);

        }
    }
}