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
            int[] treeNumbers = new int[] { 15, 8, 22, 6, 55, 12, 19, 1, 34, 67, 2, 1111 };
            JSLTree tree = new JSLTree();
            for (int i = 0; i < treeNumbers.Length; i++)
                tree.Add(treeNumbers[i]);

            var value = tree.GetTreeNodePosInfo();
            tree.OutputTreeToText(value);

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
