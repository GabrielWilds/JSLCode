using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSLTrees
{
    class JSLTreeNode
    {
        public JSLTreeNode(int content, JSLTreeNode parent)
        {
            Value = content;
            Parent = parent;
            Balance = 0;
        }

        public int Value
        {
            get;
            set;
        }

        public JSLTreeNode Parent
        {
            get;
            set;
        }

        public JSLTreeNode Left
        {
            get;
            set;
        }

        public JSLTreeNode Right
        {
            get;
            set;
        }

        public int Balance
        {
            get;
            set;
        }
    }
}
