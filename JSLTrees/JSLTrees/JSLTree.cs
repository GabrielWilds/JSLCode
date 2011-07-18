﻿using System;
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
                var list = GetTreeNodePosInfo();
                OutputTreeToText(list);
            }

            if (node.Balance > 1)
                RotateLeft(node);
            else if (node.Balance < -1)
                RotateRight(node);

            if (LeftCount > RightCount)
                return LeftCount + 1;
            else
                return RightCount + 1;
        }

        public void RotateRight(JSLTreeNode parentNode)
        {
            //counter clockwise
            JSLTreeNode newParent = parentNode.Left;
            parentNode.Left = parentNode.Left.Right;
            newParent.Right = parentNode;
            if (parentNode.Parent != null)
            {
                if (parentNode.Parent.Left != parentNode)
                    parentNode.Parent.Right = newParent;
                else if (parentNode.Parent.Right != parentNode)
                    parentNode.Parent.Left = newParent;
            }
            else if (parentNode.Parent == null)
                Root = newParent;
        }

        public void RotateLeft(JSLTreeNode parentNode)
        {
            //clockwise
            JSLTreeNode newParent = parentNode.Right;
            parentNode.Right = parentNode.Right.Left;
            newParent.Left = parentNode;
            if (parentNode.Parent != null)
            {
                if (parentNode.Parent.Left != parentNode)
                    parentNode.Parent.Right = newParent;
                else if (parentNode.Parent.Right != parentNode)
                    parentNode.Parent.Left = newParent;
            }
            else if (parentNode.Parent == null)
                Root = newParent;
        }
    }
}
