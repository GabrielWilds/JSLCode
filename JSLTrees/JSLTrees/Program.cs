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
            Random random = new Random();
            int[] treeNumbers = new int[] { 10, 5, 8, 11, 4, 3, 20 };
            //int[] treeNumbers = new int[100];
            //for(int i = 0; i < treeNumbers.Length; i++)
            //    treeNumbers[i] = random.Next(10,1000);

            JSLTree tree = new JSLTree();
            tree.Add(treeNumbers);

            var value = tree.GetTreeNodePosInfo();
            tree.OutputTreeToText(value);
            //Console.WriteLine("Check file now. Press Any Key.");
            //Console.ReadKey();
            //Console.Clear();

            //tree.BalanceTree();

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
