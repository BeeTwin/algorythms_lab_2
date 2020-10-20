using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using static System.Math;

namespace algorythms_lab_2
{
    public class StackCalculator
    {
        public Stack<string> Stack;
        public Dictionary<string, double> Variables;
        public string InfixForm { get => _input[0]; }

        private Dictionary<string, Func<double, double, double>> _dict;
        private Dictionary<string, byte> _priorities;
        private string[] _input;

        public StackCalculator(string path)
        {
            InitializeDict();
            _input = File.ReadAllLines(path);
            Stack = ChangeToPrefix(_input[0]);
            InitializeVariables(_input);
        }

        public double Execute()
        {
            var opStack = new Stack<double>();
            string current;
            while (Stack.Any())
                if (_dict.ContainsKey(current = Stack.Pop()))
                    opStack.Push(_dict[current](
                        opStack.Pop(), 
                        IsBinary(current) ? opStack.Pop() : -1));
                else
                    opStack.Push(
                        Variables.ContainsKey(current) ? 
                        Variables[current] : 
                        double.Parse(current, System.Globalization.CultureInfo.InvariantCulture));

            return opStack.Pop();
        }

        private void InitializeVariables(string[] input)
        {
            Variables = new Dictionary<string, double>();
            for(var i = 1; i < _input.Length; i++)
            {
                var nameAndValue = _input[i].Split('=');
                var name = nameAndValue[0].Trim(); 
                var value = nameAndValue[1].Trim();
                Variables[name] = double.Parse(value);
            }
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

            return result.Reverse();
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
            _dict["+"]    = (a, b) => b + a;        _priorities["+"]    = 1;
            _dict["-"]    = (a, b) => b - a;        _priorities["-"]    = 1;
            _dict["*"]    = (a, b) => b * a;        _priorities["*"]    = 2;
            _dict["/"]    = (a, b) => b / a;        _priorities["/"]    = 2;
            _dict["^"]    = (a, b) => Pow(b, a);    _priorities["^"]    = 3;
            _dict["ln"]   = (a, b) => Log(a);       _priorities["ln"]   = 4;
            _dict["cos"]  = (a, b) => Cos(a);       _priorities["cos"]  = 4;
            _dict["sin"]  = (a, b) => Sin(a);       _priorities["sin"]  = 4;
            _dict["sqrt"] = (a, b) => Sqrt(a);      _priorities["sqrt"] = 4;
                                                    _priorities["("] = 0;
        }

        private bool IsBinary(string op)
            => op switch
            {
                "+" => true,
                "-" => true,
                "*" => true,
                "/" => true,
                "^" => true,
                _   => false
            };
    }
}
