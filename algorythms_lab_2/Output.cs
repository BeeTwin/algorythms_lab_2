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
                "input1_1_10.txt",
                "input1_2_10.txt",
                "input1_3_10.txt",
                "input1_1_50.txt",
                "input1_2_50.txt",
                "input1_3_50.txt",
                "input1_1_100.txt",
                "input1_2_100.txt",
                "input1_3_100.txt",
                "input1_1_500.txt",
                "input1_2_500.txt",
                "input1_3_500.txt",
                "input1_1_1000.txt",
                "input1_2_1000.txt",
                "input1_3_1000.txt",
            };
        private string[] _pathsSecond = new string[]
            {
                "input2_1.txt",
                "input2_2.txt",
                "input2_3.txt",
                "input2_4.txt",
                "input2_5.txt"
            };
        private double _iterations = 1000000;


        public void FirstPath()
        {
            var isFirst = true;
            ShowTable();
            foreach (var p in _pathsFirst)
            {
                if(isFirst)
                    for (var i = 0; i < _iterations; i++)
                    {
                        var timeA = new TimeAnalizer();
                        var t0 = new TxtStackExecutor();
                        timeA.Actions += () => t0.Append(p);
                        timeA.Actions += () => t0.Execute();
                        timeA.Analyze();
                    }
                isFirst = false;
                double time = 0;
                for (var i = 0; i < _iterations; i++)
                {
                    var timeAnalizer = new TimeAnalizer();
                    var t = new TxtStackExecutor();
                    timeAnalizer.Actions += () => t.Append(p);
                    timeAnalizer.Actions += () => t.Execute();
                    time += timeAnalizer.Analyze();
                }
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
            Write($"{path} \t:");
            ResetColor();
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"\t{time}");
            ResetColor();
        }

        public void SecondPath()
        {
            WriteLine("File name or num 1-5: ");
            for(var i = 1; i <= _pathsSecond.Length; i++)
                WriteLine($"{i}) {_pathsSecond[i-1]}");
            var path = ReadLine();
            if (!path.Contains(".txt"))
                path = _pathsSecond[int.Parse(path) -1];
            Clear();
            WriteLine($"File: {path}");
            var c = new StackCalculator(path);
            WriteLine("Infix form:");
            WriteLine($"\t{c.InfixForm}");
            WriteLine("Postfix form:");
            WriteLine($"\t{c.Stack.ToString().Replace(",", "")}");
            WriteLine("Variables:");
            foreach(var v in c.Variables)
                WriteLine($"\t {v.Key} = {v.Value}");
            WriteLine($"Result: {c.Execute()}");
        }


    }
}
