using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSLTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] treeNumbers = new int[] { 15, 8, 22, 6, 55, 12, 19 };
            JSLTree tree = new JSLTree();
            for (int i = 0; i < treeNumbers.Length; i++)
                tree.Add(treeNumbers[i]);

            tree.GetTreeHeight(tree.Root, 0);
            NodePositionInfo rootInfo = new NodePositionInfo(2 ^ (tree.TreeLength - 1), tree.Root.Value.ToString());
            List<List<NodePositionInfo>> list = new List<List<NodePositionInfo>>();
            for (int i = 0; i < tree.TreeLength; i++)
                list.Add(new List<NodePositionInfo>());
            list[0].Add(rootInfo);
            tree.GetTreeNodePosInfo(tree.Root.Left, list, 0, 0);
            tree.OutputTreeToText(list);
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
