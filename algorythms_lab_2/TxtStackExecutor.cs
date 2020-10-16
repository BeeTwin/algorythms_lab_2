using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace algorythms_lab_2
{
    public class TxtStackExecutor<T>
    {
        private class ParseItem
        {
            public StackAction StackAction;
            public T Value;
        }

        private enum StackAction
        {
            Push,
            Pop,
            Peek,
            Any,
            ToString
        }

        private Stack<T> _stack = new Stack<T>();
        private List<ParseItem> _parseItems = new List<ParseItem>();
        private Dictionary<StackAction, Action<T>> _dict;

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
            _dict = new Dictionary<StackAction, Action<T>>();
            _dict[StackAction.Push]     = (value) => _stack.Push(value);
            _dict[StackAction.Pop]      = (_)     => _stack.Pop();
            _dict[StackAction.Peek]     = (_)     => _stack.Peek();
            _dict[StackAction.Any]      = (_)     => _stack.Any();
            _dict[StackAction.ToString] = (_)     => Console.WriteLine(_stack);
        }

        private List<ParseItem> Parse(string path)
        {
            return null;
        }
    }
}
