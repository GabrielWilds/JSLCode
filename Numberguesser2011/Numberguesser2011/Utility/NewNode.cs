using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    class NewNode<T>
    {
        T _content;
        NewNode<T> _prev;
        NewNode<T> _next;

        public NewNode(T content)
            : this(content, null)
        {
        }


        public NewNode(T content, NewNode<T> next)
        {
            _content = content;
            _next = next;
        }


        public NewNode<T> Prev
        {
            get { return _prev; }
            set { _prev = value; }
        }

        public NewNode<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public T Content
        {
            get { return _content; }
            set { _content = value; }
        }
    }
}
