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
            int[] treeNumbers = new int[] { 15, 8, 22, 6, 55, 12, 19, 1, 34, 67, 2, 1111, 10, 9, 11, 13 };
            JSLTree tree = new JSLTree();
            tree.Add(treeNumbers);

            var value = tree.GetTreeNodePosInfo();
            tree.OutputTreeToText(value);
            Console.WriteLine("Check file now. Press Any Key.");
            Console.ReadKey();

            tree.BalanceTree();
            var value2 = tree.GetTreeNodePosInfo();
            tree.OutputTreeToText(value2);

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
