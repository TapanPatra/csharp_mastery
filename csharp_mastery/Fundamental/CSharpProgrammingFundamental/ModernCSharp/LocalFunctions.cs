using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._04_ModernCSharp
{
    public class Tree
    {
        public int Value { get; }
        private Tree? Left { get; }
        private Tree? Right { get; }

        public Tree(int value, Tree? left =null, Tree? right =null)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public void PrintInPreOrder(string format)
        {
            PrintInPreOrder(this);
            void PrintInPreOrder(Tree tree)
            {
                if (tree == null) return;

                PrintValue(tree, format);
                PrintInPreOrder(tree.Left);
                PrintInPreOrder(tree.Right);
            }
        }

        public void PrintInOrder(string format)
        {
            PrintInOrder(this);

            void PrintInOrder(Tree tree)
            {
                if (tree == null) { return; }

                PrintInOrder(tree.Left);
                PrintInOrder(tree.Right);
                PrintValue(tree, format);
            }
        }

        public void PrintInPostOrder(string format)
        {
            PrintInPostOrder(this);

            void PrintInPostOrder(Tree tree)
            {
                if (tree == null) { return; }

                PrintInPostOrder(tree.Left);
                PrintInPostOrder(tree);
                PrintValue(tree.Right, format);

            }
        }

        private static void PrintValue(Tree tree, string format)
        {
            Console.WriteLine($"{format}", tree.Value);
        }

    }

    [TestFixture]
    public class LocalFunctions
    {
        [Test]
        public void LocalFunctionsTest()
        {


            var tree = new Tree(4,
                                new Tree(2, new Tree(1), new Tree(3)),
                                new Tree(6, new Tree(5), new Tree(7))
                                );

            Console.WriteLine("Print In Order :");
            tree.PrintInOrder("{0}");
           //Console.WriteLine("Print In PostOrder :");
            //tree.PrintInPostOrder("<{0}>");
            //Console.WriteLine("Print In PreOrder :");
            //tree.PrintInPreOrder("[{0}]");



        }
    }
}
