using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {

            BinaryTreeNode<int> root = new BinaryTreeNode<int>();
            root.Data = 100;
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Root = root;


            var node1 = new BinaryTreeNode<int>() { Data = 2 };
            var node2 = new BinaryTreeNode<int>() { Data = 5 };
            root.Left = node1;
            root.Right = node2;

            node1.Parent = root;
            node2.Parent = root;

            var node11 = new BinaryTreeNode<int>() { Data = 11 };
            var node12 = new BinaryTreeNode<int>() { Data = 13 };
            var node13 = new BinaryTreeNode<int>() { Data = 19 };
            node1.Left = node11;
            node1.Right = node12;
            node2.Right = node13;

            node11.Parent = node1;
            node12.Parent = node1;
            node13.Parent = node2;

            var node21 = new BinaryTreeNode<int>() { Data = 20 };
            var node22 = new BinaryTreeNode<int>() { Data = 28 };
            var node23 = new BinaryTreeNode<int>() { Data = 29 };
            node11.Left = node21;
            node11.Right = node22;
            node13.Left = node23;

            node21.Parent = node11;
            node22.Parent = node11;
            node23.Parent = node13;

            Console.WriteLine($"This height is {tree.GetHeight()}");
            Console.ReadLine();
        }
    }

    public class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Parent { get; set; }
        public List<TreeNode<T>> Children { get; set; }
        public int GetHeight()
        {
            int height = 1;
            TreeNode<T> current = this;
            while(current.Parent != null)
            {
                height++;
                current = current.Parent;
            }
            return height;
        }
    }

    public class BinaryTreeNode<T> : TreeNode<T>
    {
        public BinaryTreeNode() => Children =
            new List<TreeNode<T>>() { null, null };

        public BinaryTreeNode<T> Left
        {
            get { return (BinaryTreeNode<T>)Children[0]; }
            set { Children[0] = value; }
        }

        public BinaryTreeNode<T> Right
        {
            get { return (BinaryTreeNode<T>)Children[1]; }
            set { Children[1] = value; }
        }
    }

    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; set; }
        public int count { get; set; }
        public enum TraversalEnum
        {
            PREORDER,
            INORDER,
            POSTORDER
        }
        public int GetHeight()
        {
            int height = 0;
            foreach (BinaryTreeNode<T> node in Traverse(TraversalEnum.PREORDER))
            {
                height = Math.Max(height, node.GetHeight());
            }
            return height;
        }

        public List<BinaryTreeNode<T>> Traverse(TraversalEnum mode)
        {
            List<BinaryTreeNode<T>> nodes = new List<BinaryTreeNode<T>>();
            switch(mode)
            {
                case TraversalEnum.PREORDER:
                    TraversePreOrder(Root, nodes);
                    break;
                case TraversalEnum.INORDER:
                    TraverseInOrder(Root, nodes);
                    break;
                case TraversalEnum.POSTORDER:
                    TraversePostOrder(Root, nodes);
                    break;
            }
            return nodes;
        }


        private void TraversePreOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
        {
            if (node != null)
            {
                result.Add(node);
                TraversePreOrder(node.Left, result);
                TraversePreOrder(node.Right, result);
            }
        }

        private void TraverseInOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
        {
            if (node != null)
            {
                TraverseInOrder(node.Left, result);
                result.Add(node);
                TraverseInOrder(node.Right, result);
            }
        }

        private void TraversePostOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
        {
            if (node != null)
            {
                TraverseInOrder(node.Left, result);
                TraverseInOrder(node.Right, result);
                result.Add(node);
            }
        }
    }
}
