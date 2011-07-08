using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            TreeExamination(tree, tree.Root, 0);
            List<int[]> list = new List<int[]>();

            int arraySize = 1;
            for (int i = 0; i < this.TreeLength; i++)
            {
                list.Add(new int[arraySize]);
                arraySize += arraySize;
            }

            TreeRecursion(Root, list, 0, 0, 0);
            RenderTree(list);
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

                    for(int y = 0; y < (bufferSize - lineLength); y++)
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

        static void TreeExamination(JSLTree tree, JSLTreeNode curNode, int layerCount)
        {
            if (curNode.Left != null)
            {
                layerCount++;
                TreeExamination(tree, curNode.Left, layerCount);
            }
            else if (layerCount > tree.TreeLength)
                tree.TreeLength = layerCount;
            if (curNode.Right != null)
            {
                layerCount++;
                TreeExamination(tree, curNode.Right, layerCount);
            }
            else if (layerCount > tree.TreeLength)
                tree.TreeLength = layerCount;
        }

        static void TreeRecursion(JSLTreeNode curNode, List<int[]> list, int layerCount, int leftCount, int rightCount)
        {
            int position = rightCount - leftCount;
            if (position < 0)
                position = 0;

            list[layerCount][position] = curNode.Value;
            layerCount++;

            if (curNode.Left != null)
            {
                leftCount++;
                TreeRecursion(curNode.Left, list, layerCount, leftCount, rightCount);
            }

            if (curNode.Right != null)
            {
                rightCount++;
                TreeRecursion(curNode.Right, list, layerCount, leftCount, rightCount);
            }
        }


    }
}
