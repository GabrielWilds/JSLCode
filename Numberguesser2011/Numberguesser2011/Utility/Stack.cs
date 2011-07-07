using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    class Stack<T>
    {
        NewLinked<T> _list = new NewLinked<T>();


        public void Push(T value)
        {
            _list.Add(value);
        }

        public Object Pop()
        {
            int listIndex = _list.Length;
            Object lastObj = _list.Get(listIndex - 1);
            _list.RemoveAt(listIndex - 1);
            return lastObj;
        }
    }
}
