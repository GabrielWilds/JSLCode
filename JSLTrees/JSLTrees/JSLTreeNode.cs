using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSLTrees
{
    class JSLTreeNode
    {
        public JSLTreeNode(int content)
        {
            Value = content;
        }

        public int Value
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
    }
}
