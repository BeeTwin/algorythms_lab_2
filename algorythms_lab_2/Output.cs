using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static System.Console;

namespace algorythms_lab_2
{
    class Output
    {

        private string[] _pathsFirst = new string[] 
            {
                "input1_1.txt",
                "input1_2.txt",
                "input1_3.txt",
                "input1_4.txt",
                "input1_5.txt"
            };
        private string[] _pathsSecond = new string[]
            {
                "input2_1.txt",
                "input2_2.txt",
                "input2_3.txt",
                "input2_4.txt",
                "input2_5.txt"
            };
        private double _iterations = 1000;


        public void FirstPath()
        {
            ShowTable();
            foreach (var p in _pathsFirst)
            {
                double time = 0;
                var timeAnalizer = new TimeAnalizer();
                var t = new TxtStackExecutor();
                timeAnalizer.Actions += () => t.Append(p);
                timeAnalizer.Actions += () => t.Execute();
                for (var i = 0; i < _iterations; i++)
                    time += timeAnalizer.Analyze();
                ShowInConsoleFirstPath(p, Math.Round(time / _iterations, 10));
            }

        }

        private void ShowTable()
        {
            Write($"Files\t");
            WriteLine($"\tTotal milliseconds");
        }

        public void ShowInConsoleFirstPath(string path, double time)
        {
            ForegroundColor = ConsoleColor.Blue;
            Write($"{path}\t:");
            ResetColor();
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"\t{time}");
            ResetColor();
        }

        public void SecondPath()
        {
            Write("File name: ");
            var path = ReadLine();
            WriteLine($"\t{path}");
            var c = new StackCalculator(path);
            WriteLine("Infix form:");
            WriteLine($"\t{c.InfixForm}");
            WriteLine("Postfix form:");
            WriteLine($"\t{c.Stack}");
            WriteLine("Variables:");
            foreach(var v in c.Variables)
                WriteLine($"\t {v.Key} = {v.Value}");
            WriteLine($"Result: {c.Execute()}");
        }


    }
}
