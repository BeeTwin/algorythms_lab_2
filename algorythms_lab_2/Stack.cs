using System.Text;

namespace algorythms_lab_2
{
    public class Stack<T>
    {
        private class StackItem
        {
            public T Value;
            public StackItem Previous;

            public StackItem(T value, StackItem previous)
            {
                Value = value;
                Previous = previous;
            }

            public override string ToString() => Value.ToString();
        }

        private StackItem _top;

        public Stack() { }

        public Stack(Stack<T> stack)
        {
            _top = new StackItem(stack._top.Value, stack._top.Previous);
        }

        public void Push(T value) //Push(elem)
        {
            _top = new StackItem(value, _top);
        }

        public T Pop() //Pop()
        {
            var top = _top;
            _top = _top.Previous;
            return top.Value;
        }

        public T Peek() //Top()
        {
            return _top.Value;
        }

        public bool Any() //isEmpty()
        {
            return _top != null;
        }

        public override string ToString() //Print()
        {
            var sb = new StringBuilder();
            var current = _top;
            while (current != null)
            {
                sb.Append($"{current.Value}, ");
                current = current.Previous;
            }
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
    }
}
