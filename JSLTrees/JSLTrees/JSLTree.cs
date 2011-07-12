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

        public void Add(int content)
        {
            JSLTreeNode curNode = Root;
            if (Root == null)
                Root = new JSLTreeNode(content);
            else
            {
                while (true)
                {
                    if (curNode.Value < content)
                    {
                        if (curNode.Right == null)
                        {
                            curNode.Right = new JSLTreeNode(content);
                            break;
                        }
                        else
                            curNode = curNode.Right;
                    }
                    else
                    {
                        if (curNode.Left == null)
                        {
                            curNode.Left = new JSLTreeNode(content);
                            break;
                        }
                        else
                            curNode = curNode.Left;
                    }
                }
            }
        }

        public void DisplayTree(JSLTree tree)
        {
            GetTreeHeight(tree.Root, 0);
            List<int[]> list = new List<int[]>();

            int arraySize = 1;
            for (int i = 0; i < this.TreeLength; i++)
            {
                list.Add(new int[arraySize]);
                arraySize += arraySize;
            }

            //TreeRecursion(Root, list, 0, 0, 0);
            //RenderTree(list);
        }

        static void RenderTree(List<int[]> list)
        {
            string[] treeOutput = new string[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                int bufferSize = Console.WindowWidth / (list[i].Length + 1);
                for (int x = 0; x < list[i].Length; x++)
                {
                    StringBuilder currentLine = new StringBuilder();

                    int lineLength = 1;
                    if (list[i][x] > 9 && list[i][x] < 100)
                        lineLength = 2;
                    else if (list[i][x] > 99 && list[i][x] < 1000)
                        lineLength = 3;
                    else if (list[i][x] > 999 && list[i][x] < 10000)
                        lineLength = 4;
                    else if (list[i][x] > 9999)
                        lineLength = 5;

                    for (int y = 0; y < (bufferSize - lineLength); y++)
                        currentLine.Append(' ');
                    currentLine.Append(list[i][x].ToString());
                    treeOutput[i] = currentLine.ToString();
                }

            }
            for (int i = 0; i < treeOutput.Length; i++)
            {
                Console.WriteLine(treeOutput[i]);
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public void GetTreeHeight(JSLTreeNode curNode, int layerCount)
        {
            if (curNode.Left != null)
            {
                layerCount++;
                GetTreeHeight(curNode.Left, layerCount);
            }
            else if (layerCount > TreeLength)
                TreeLength = layerCount;
            if (curNode.Right != null)
            {
                layerCount++;
                GetTreeHeight(curNode.Right, layerCount);
            }
            else if (layerCount > TreeLength)
                TreeLength = layerCount;
        }

        public void GetTreeNodePosInfo(JSLTreeNode curNode, List<List<NodePositionInfo>> list, int curPos, int curLayer)
        {
            NodePositionInfo info = new NodePositionInfo(curPos, curNode.Value.ToString());
            list[curLayer].Add(info);

            if (curNode.Left != null)
            {
                GetTreeNodePosInfo(curNode.Left, list, curPos - 2 ^ (list.Count - curLayer - 1), curLayer + 1);
            }

            if (curNode.Right != null)
            {
                GetTreeNodePosInfo(curNode.Right, list, curPos + 2 ^ (list.Count - curLayer - 1), curLayer + 1);
            }
        }

        public void OutputTreeToText(List<List<NodePositionInfo>> list)
        {
            String[] layers = new String[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                for (int x = 0; x < list[i].Count; x++)
                {
                    StringBuilder layerPadded = new StringBuilder();
                    for (int y = 0; y < list[x][y].Position; y++)
                        layerPadded.Append('\t');
                    layerPadded.Append(list[i][x].NodeValue);
                    
                    layers[i] = layerPadded.ToString();
                }
            }

            File.WriteAllLines("tree.txt", layers);
        }

    }
}
