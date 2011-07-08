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
            int[] treeNumbers = new int[] { 5, 8, 2, 6, 55, 4 };
            JSLTree tree = new JSLTree();
            for (int i = 0; i < treeNumbers.Length; i++)
                tree.Add(treeNumbers[i]);

            tree.DisplayTree(tree);
            Console.ReadKey();
        }
    }
}
