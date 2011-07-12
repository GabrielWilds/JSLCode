using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSLTrees
{
    class NodePositionInfo
    {
        public NodePositionInfo(int pos, string value)
        {
            NodeValue = value;
            Position = pos;
        }
        public string NodeValue
        {
            get;
            set;
        }

        public int Position
        {
            get;
            set;
        }
    }
}
