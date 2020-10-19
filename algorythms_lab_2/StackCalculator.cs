using System;
using System.Collections.Generic;
using System.IO;
using static System.Math;

namespace algorythms_lab_2
{
    public class StackCalculator
    {
        public Stack<string> Stack;
        public Dictionary<string, double> Variables;

        private Dictionary<string, Func<double, double, double>> _dict;
        private Dictionary<string, byte> _priorities;
        private string[] _input;

        public StackCalculator(string path)
        {
            InitializeDict();
            _input = File.ReadAllLines(path);
            Stack = ChangeToPrefix(_input[0]);
            Variables = InitializeVariables(_input);
        }

        public double Execute()
        {
            while (true)
            {

            }
        }

        private Dictionary<string, double> InitializeVariables(string[] input)
        {
            var output = new Dictionary<string, double>();
            for(var i = 1; i < _input.Length; i++)
            {
                var nameAndValue = _input[i].Split('=');
                var name = nameAndValue[0].Trim(); 
                var value = nameAndValue[1].Trim();
                output[name] = int.Parse(value);
            }
            return output;
        }

        private Stack<string> ChangeToPrefix(string input)
        {
            var splittedInput = input.Split(' ');
            var opStack = new Stack<string>();
            var result = new Stack<string>();

            for (var i = 0; i < splittedInput.Length; i++)
            {
                var current = splittedInput[i];
                if (_dict.ContainsKey(current))
                {
                    if (opStack.Any() && _priorities[opStack.Peek()] > _priorities[current])
                        result.Push(opStack.Pop());
                    opStack.Push(current);
                }
                else if (current == "(")
                    opStack.Push(current);
                else if (current == ")")
                {
                    EmptyOpStack(opStack, result);
                    opStack.Pop();
                }
                else
                    result.Push(current);
            }
            EmptyOpStack(opStack, result);

            return result;
        }

        private void EmptyOpStack(Stack<string> opStack, Stack<string> result)
        {
            while (opStack.Any() && opStack.Peek() != "(")
                result.Push(opStack.Pop());
        }

        private void InitializeDict()
        {
            _dict = new Dictionary<string, Func<double, double, double>>();
            _priorities = new Dictionary<string, byte>();
            _dict["+"]    = (a, b) => a + b;        _priorities["+"]    = 1;
            _dict["-"]    = (a, b) => a - b;        _priorities["-"]    = 1;
            _dict["*"]    = (a, b) => a * b;        _priorities["*"]    = 2;
            _dict["/"]    = (a, b) => a / b;        _priorities["/"]    = 2;
            _dict["^"]    = (a, b) => Pow(a, b);    _priorities["^"]    = 3;
            _dict["ln"]   = (a, _) => Log(a);       _priorities["ln"]   = 3;
            _dict["cos"]  = (a, _) => Cos(a);       _priorities["cos"]  = 3;
            _dict["sin"]  = (a, _) => Sin(a);       _priorities["sin"]  = 3;
            _dict["sqrt"] = (a, _) => Sqrt(a);      _priorities["sqrt"] = 3;
            _priorities["("] = 0;
        }
    }
}
