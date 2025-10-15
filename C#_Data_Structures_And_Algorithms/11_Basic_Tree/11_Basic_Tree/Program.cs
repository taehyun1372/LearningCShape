using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Basic_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Tree<string> tree = new Tree<string>();
            TreeNode<string> node100 = new TreeNode<string>() { Data = "100" };

            TreeNode<string> node50 = new TreeNode<string>() { Data = "50" };
            TreeNode<string> node1 = new TreeNode<string>() { Data = "1" };
            TreeNode<string> node150 = new TreeNode<string>() { Data = "150" };

            TreeNode<string> node12 = new TreeNode<string>() { Data = "12" };
            TreeNode<string> node70 = new TreeNode<string>() { Data = "70" };
            TreeNode<string> node61 = new TreeNode<string>() { Data = "61" };
            TreeNode<string> node30 = new TreeNode<string>() { Data = "30" };
            TreeNode<string> node5 = new TreeNode<string>() { Data = "5" };
            TreeNode<string> node11 = new TreeNode<string>() { Data = "11" };

            TreeNode<string> node45 = new TreeNode<string>() { Data = "45" };
            TreeNode<string> node21 = new TreeNode<string>() { Data = "21" };
            TreeNode<string> node96 = new TreeNode<string>() { Data = "96" };
            TreeNode<string> node9 = new TreeNode<string>() { Data = "9" };

            tree.Root = node100;


            tree.Root.Children.Add(node50);
            tree.Root.Children.Add(node1);
            tree.Root.Children.Add(node150);

            node50.Children.Add(node12);
            node1.Children.Add(node70);
            node1.Children.Add(node61);
            node150.Children.Add(node30);
            node150.Children.Add(node5);
            node150.Children.Add(node11);

            node12.Children.Add(node45);
            node12.Children.Add(node21);
            node30.Children.Add(node96);
            node30.Children.Add(node9);

            tree.DisplayTree();

            Console.ReadLine();
        }

    }
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Parent { get; set; }
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
        public int GetHeight()
        {
            int height = 1;
            TreeNode<T> current = this;
            while (current.Parent != null)
            {
                height++;
                current = current.Parent;
            }
            return height;
        }
    }

    public class Tree<T>
    {
        public TreeNode<T> Root { get; set; }

        public void DisplayTree()
        {
            if(Root is null)
            {
                return;
            }
            DisplayChildren(new List<TreeNode<T>>() { Root });
        }

        public void DisplayChildren(List<TreeNode<T>> children)
        {
            if (children.Count == 0)
            {
                return;
            }

            List<TreeNode<T>> grandChildren = new List<TreeNode<T>>();

            Console.Write("|");
            foreach (var child in children)
            {
                Console.Write(child.Data);
                Console.Write("\t");
                foreach(var grandChild in child.Children)
                {
                    grandChildren.Add(grandChild);
                }
                Console.Write("|");
            }
            Console.WriteLine();
            DisplayChildren(grandChildren);
        }
    }
}
