using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    class NewLinked<T>
    {
        NewNode<T> _head = null;
        int _nodeCount = 0;


        public int Length
        {
            get { return _nodeCount; }
        }


        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new NewNode<T>(value);
            }
            else
            {
                NewNode<T> curNode = _head;

                while (curNode.Next != null)
                {
                    curNode = curNode.Next;
                }
                curNode.Next = new NewNode<T>(value);

            }

            _nodeCount++;
        }


        public T Get(int index)
        {
            NewNode<T> curNode = _head;

            for (int i = 0; i < index; i++)
            {
                curNode = curNode.Next;
            }

            return curNode.Content;
        }


        public void RemoveAt(int index)
        {
            if (index == 0)
                _head = _head.Next;
            else
            {
                NewNode<T> curNode = _head;
                NewNode<T> prevNode = null;

                for (int i = 0; i < index; i++)
                {
                    prevNode = curNode;
                    curNode = curNode.Next;
                }

                prevNode.Next = curNode.Next;
            }

            _nodeCount--;
        }

        public void RemoveAll()
        {
            _head = null;
        }
    }
}

