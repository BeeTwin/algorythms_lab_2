using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace algorythms_lab_2
{
    public class TxtStackExecutor
    {
        private class ParseItem
        {
            public StackAction StackAction;
            public string Value;

            public ParseItem(StackAction stackAction, string value = null)
            {
                StackAction = stackAction;
                Value = value;
            }

            public override string ToString() => $"{StackAction}({Value})";
        }

        private enum StackAction
        {
            Push,
            Pop,
            Peek,
            Any,
            ToString
        }
         
        private Stack<string> _stack = new Stack<string>();
        private List<ParseItem> _parseItems = new List<ParseItem>();
        private Dictionary<StackAction, Action<string>> _dict;

        public TxtStackExecutor()
        {
            Initialize();
        }

        public void Append(string path)
        {
            _parseItems = _parseItems.Concat(Parse(path)).ToList();
        }

        public void Execute()
        {
            foreach(var parseItem in _parseItems)
                _dict[parseItem.StackAction](parseItem.Value);
        }

        private void Initialize()
        {
            _dict = new Dictionary<StackAction, Action<string>>();
            _dict[StackAction.Push]     = (value) => _stack.Push(value);
            _dict[StackAction.Pop]      = (_)     => _stack.Pop();
            _dict[StackAction.Peek]     = (_)     => _stack.Peek();
            _dict[StackAction.Any]      = (_)     => _stack.Any();
            _dict[StackAction.ToString] = (_)     => _stack.ToString();
        }

        private List<ParseItem> Parse(string path) //input is always in right form ;)
        {
            var list = new List<ParseItem>();
            var input = File.ReadAllText(path).Split(' ');
            foreach(var stackAction in input)
                if (stackAction.Contains(','))
                    list.Add(new ParseItem(StackAction.Push, stackAction.Split(',')[1]));
                else
                    list.Add(new ParseItem(Enum.Parse<StackAction>(stackAction)));
            return list;
        }
    }
}
