using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JSLTrees
{
    class JSLTree
    {
        public JSLTree()
        {
            this.Root = null;
            this.TreeLength = 0;
            this.TreeUpdateCount = 00;
        }

        public JSLTreeNode Root
        {
            get;
            set;
        }

        public int TreeLength
        {
            get;
            set;
        }

        private int TreeUpdateCount
        {
            get;
            set;
        }

        public void Add(int content)
        {
            JSLTreeNode curNode = Root;
            if (Root == null)
                Root = new JSLTreeNode(content, null);
            else
            {
                while (true)
                {
                    if (curNode.Value < content)
                    {
                        if (curNode.Right == null)
                        {
                            curNode.Right = new JSLTreeNode(content, curNode);
                            curNode.Balance++;
                            break;
                        }
                        else
                            curNode = curNode.Right;
                    }
                    else
                    {
                        if (curNode.Left == null)
                        {
                            curNode.Left = new JSLTreeNode(content, curNode);
                            curNode.Balance--;
                            break;
                        }
                        else
                            curNode = curNode.Left;
                    }
                }
            }
            var list = GetTreeNodePosInfo();
            OutputTreeToText(list);
            BalanceTree();
        }

        public void Add(int[] content)
        {
            for (int i = 0; i < content.Length; i++)
                Add(content[i]);
        }

        public void DisplayTree(JSLTree tree)
        {
            UpdateTreeHeightRecursive(tree.Root, 0);
            List<int[]> list = new List<int[]>();

            int arraySize = 1;
            for (int i = 0; i < this.TreeLength; i++)
            {
                list.Add(new int[arraySize]);
                arraySize += arraySize;
            }
        }

        private void UpdateTreeHeight()
        {
            this.UpdateTreeHeightRecursive(this.Root, 0);
        }

        private void UpdateTreeHeightRecursive(JSLTreeNode curNode, int layerCount)
        {
            layerCount++;

            if (curNode.Left != null)
                UpdateTreeHeightRecursive(curNode.Left, layerCount);
            else if (layerCount > TreeLength)
                TreeLength = layerCount;

            if (curNode.Right != null)
                UpdateTreeHeightRecursive(curNode.Right, layerCount);
            else if (layerCount > TreeLength)
                TreeLength = layerCount;
        }

        public List<List<NodePositionInfo>> GetTreeNodePosInfo()
        {
            UpdateTreeHeight();
            NodePositionInfo rootInfo = new NodePositionInfo((int)Math.Pow(2, this.TreeLength - 1), this.Root.Value.ToString());
            List<List<NodePositionInfo>> list = new List<List<NodePositionInfo>>();

            for (int i = 0; i < this.TreeLength; i++)
                list.Add(new List<NodePositionInfo>());

            list[0].Add(rootInfo);

            if (this.Root.Left != null)
                this.GetTreeNodePosInfoRecursive(this.Root.Left, list, GetChildPosition(list.Count, rootInfo.Position, 0, true), 1);
            if (this.Root.Right != null)
                this.GetTreeNodePosInfoRecursive(this.Root.Right, list, GetChildPosition(list.Count, rootInfo.Position, 0, false), 1);

            return list;
        }

        private void GetTreeNodePosInfoRecursive(JSLTreeNode curNode, List<List<NodePositionInfo>> list, int curPos, int curLayer)
        {
            NodePositionInfo info = new NodePositionInfo(curPos, curNode.Value.ToString());
            list[curLayer].Add(info);

            if (curNode.Left != null)
                GetTreeNodePosInfoRecursive(curNode.Left, list, GetChildPosition(list.Count, curPos, curLayer, true), curLayer + 1);

            if (curNode.Right != null)
                GetTreeNodePosInfoRecursive(curNode.Right, list, GetChildPosition(list.Count, curPos, curLayer, false), curLayer + 1);

        }

        private int GetChildPosition(int treeHeight, int curPosition, int curLayer, bool isLeftChild)
        {
            int value = (int)Math.Pow(2, (treeHeight - curLayer - 2));

            if (isLeftChild)
                value = curPosition - value;
            else
                value += curPosition;

            return value;
        }

        public void OutputTreeToText(List<List<NodePositionInfo>> list)
        {
            TreeUpdateCount++;
            String[] layers = new String[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                for (int x = 0; x < list[i].Count; x++)
                {
                    StringBuilder layerPadded = new StringBuilder();

                    int relativePosition = list[i][x].Position;
                    if (x > 0)
                        relativePosition = relativePosition - list[i][x - 1].Position;

                    for (int y = 0; y < relativePosition; y++)
                        layerPadded.Append("  ");

                    layerPadded.Append(list[i][x].NodeValue);

                    layers[i] += layerPadded.ToString();
                }
            }

            File.WriteAllLines("tree" + TreeUpdateCount.ToString("00") + ".txt", layers);
        }

        public void BalanceTree()
        {
            BalanceSubTree(Root);
        }

        public int BalanceSubTree(JSLTreeNode node)
        {

            int LeftCount = 0;
            if (node.Left != null)
                LeftCount = BalanceSubTree(node.Left);

            int RightCount = 0;
            if (node.Right != null)
                RightCount = BalanceSubTree(node.Right);

            node.Balance = RightCount - LeftCount;
            Console.WriteLine("Node: " + node.Value.ToString() + ", Node Balance: " + node.Balance.ToString());

            if (node.Balance > 1 || node.Balance < -1)
            {
                RotateNode(node);
                var list = GetTreeNodePosInfo();
                OutputTreeToText(list);
            }

            if (LeftCount > RightCount)
                return LeftCount + 1;
            else
                return RightCount + 1;
        }

        private void RotateNode(JSLTreeNode Node)
        {
                if (Node.Balance > 1)
                {
                    if (Node.Right.Balance < 0 && Node.Right.Left != null)
                        RotateFromRightLeft(Node);
                    else
                        RotateFromRightRight(Node);
                }
                else if (Node.Balance < -1)
                {
                    if (Node.Left.Balance > 0 && Node.Left.Right != null)
                        RotateFromLeftRight(Node);
                    else
                        RotateFromLeftLeft(Node);
                }
        }

        private void RotateFromLeftLeft(JSLTreeNode curNode)
        {
            //counter clockwise
            JSLTreeNode newParent = curNode.Left;
            curNode.Left = curNode.Left.Right;
            newParent.Right = curNode;

            if (curNode.Parent != null)
            {
                if (curNode.Parent.Left != curNode)
                    curNode.Parent.Right = newParent;
                else if (curNode.Parent.Right != curNode)
                    curNode.Parent.Left = newParent;

                newParent.Parent = curNode.Parent;
            }
            else if (curNode.Parent == null)
                Root = newParent;


            newParent.Right.Parent = newParent;
        }

        private void RotateFromLeftRight(JSLTreeNode curNode)
        {
            //counter clockwise, with the parent's left's right child becoming the new parent.
            JSLTreeNode newParent = new JSLTreeNode(curNode.Left.Right.Value, curNode.Parent);
            newParent.Left = curNode.Left;
            newParent.Right = curNode;

            bool LeftRightLeftNull = false;
            if (curNode.Left.Right.Left != null)
                newParent.Left.Right = curNode.Left.Right.Left;
            else
                LeftRightLeftNull = true;

            if (curNode.Left.Right.Right != null)
                newParent.Right.Left = curNode.Left.Right.Right;
            else
                newParent.Right.Left = null;

            if (LeftRightLeftNull)
                newParent.Left.Right = null;

            if (curNode.Parent != null)
            {
                if (curNode.Parent.Left != curNode)
                    curNode.Parent.Right = newParent;
                else if (curNode.Parent.Right != curNode)
                    curNode.Parent.Left = newParent;

                newParent.Parent = curNode.Parent;
            }
            else if (curNode.Parent == null)
                Root = newParent;

            newParent.Left.Parent = newParent;
            newParent.Right.Parent = newParent;
        }

        private void RotateFromRightRight(JSLTreeNode curNode)
        {
            //clockwise
            JSLTreeNode newParent = curNode.Right;
            curNode.Right = curNode.Right.Left;
            newParent.Left = curNode;

            if (curNode.Parent != null)
            {
                if (curNode.Parent.Left != curNode)
                    curNode.Parent.Right = newParent;
                else if (curNode.Parent.Right != curNode)
                    curNode.Parent.Left = newParent;

                newParent.Parent = curNode.Parent;
            }
            else if (curNode.Parent == null)
                Root = newParent;

            newParent.Left.Parent = newParent;
            newParent.Right.Parent = newParent;
        }

        private void RotateFromRightLeft(JSLTreeNode curNode)
        {
            //clockwise, with the parent's right's left child becoming the new parent.
            JSLTreeNode newParent = new JSLTreeNode(curNode.Right.Left.Value, curNode.Parent);
            newParent.Left = curNode;
            newParent.Right = curNode.Right;

            bool RightLeftRightNull = false;
            if (curNode.Right.Left.Right != null)
                newParent.Right.Left = curNode.Right.Left.Right;
            else
                RightLeftRightNull = true;

            if (curNode.Right.Left.Left != null)
                curNode.Right = curNode.Right.Left.Left;
            else
                curNode.Right = null;

            if (RightLeftRightNull)
                newParent.Right.Left = null;

            if (curNode.Parent != null)
            {
                if (curNode.Parent.Left != curNode)
                    curNode.Parent.Right = newParent;
                else if (curNode.Parent.Right != curNode)
                    curNode.Parent.Left = newParent;

                newParent.Parent = curNode.Parent;
            }
            else if (curNode.Parent == null)
                Root = newParent;

            newParent.Left.Parent = newParent;
            newParent.Right.Parent = newParent;
        }
    }
}
