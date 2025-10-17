using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace _16_TreeNode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Tree _tree;
        private Node _node1;
        private Node _node2;
        private Node _node3;
        private Node _node11;
        private Node _node12;
        private Node _node21;
        private Node _node22;
        private Node _node31;

        public MainWindow()
        {
            InitializeComponent();

            Tree tree = new Tree();
            _tree = tree;

            Node root = new Node() { Data = "root" };

            Node node1 = new Node() { Data = "node1" };
            Node node2 = new Node() { Data = "node2" };
            Node node3 = new Node() { Data = "node3" };

            _node1 = node1;
            _node2 = node2;
            _node3 = node3;

            Node node11 = new Node() { Data = "node11" };
            Node node12 = new Node() { Data = "node12" };
            Node node21 = new Node() { Data = "node21" };
            Node node22 = new Node() { Data = "node22" }; 
            Node node31 = new Node() { Data = "node31" };

            _node11 = node11;
            _node12 = node12;
            _node21 = node21;
            _node22 = node22;
            _node31 = node31;

            tree.Root.Add(root);

            root.AddChild(node1);
            root.AddChild(node2);
            root.AddChild(node3);

            node1.AddChild(node11);
            node1.AddChild(node12);
            node2.AddChild(node21);
            node2.AddChild(node22);
            node3.AddChild(node31);

            this.DataContext = tree;
        }

        private void OnBubblingClicked(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index;
            if (int.TryParse(button.Content.ToString(), out index))
            {
                if (index == 1)
                {
                    _node1.RaiseBubbleEvent();
                }
                else if(index == 2)
                {
                    _node2.RaiseBubbleEvent();
                }
                else if (index == 3)
                {
                    _node3.RaiseBubbleEvent();
                }
                else if (index == 11)
                {
                    _node11.RaiseBubbleEvent();
                }
                else if (index == 12)
                {
                    _node12.RaiseBubbleEvent();
                }
                else if (index == 21)
                {
                    _node21.RaiseBubbleEvent();
                }
                else if (index == 22)
                {
                    _node22.RaiseBubbleEvent();
                }
                else if (index == 31)
                {
                    _node31.RaiseBubbleEvent();
                }
            }
        }

        private void OnTunnelingClicked(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index;
            if (int.TryParse(button.Content.ToString(), out index))
            {
                if (index == 1)
                {
                    _node1.RaiseTunnelEvent();
                }
                else if (index == 2)
                {
                    _node2.RaiseTunnelEvent();
                }
                else if (index == 3)
                {
                    _node3.RaiseTunnelEvent();
                }
                else if (index == 11)
                {
                    _node11.RaiseTunnelEvent();
                }
                else if (index == 12)
                {
                    _node12.RaiseTunnelEvent();
                }
                else if (index == 21)
                {
                    _node21.RaiseTunnelEvent();
                }
                else if (index == 22)
                {
                    _node22.RaiseTunnelEvent();
                }
                else if (index == 31)
                {
                    _node31.RaiseTunnelEvent();
                }
            }
        }
    }

    public class Tree
    {
        public Tree()
        {
        }

        public ObservableCollection<Node> Root { get; set; } = new ObservableCollection<Node>();
    }

    public class Node
    {
        public event Action<object> BubbleEvent;
        public event Action<object> TunnelEvent;


        public Node()
        {
            BubbleEvent += OnBubbleEventHandler;
            TunnelEvent += OnTunnelEventHandler;
        }

        public void RaiseBubbleEvent()
        {
            BubbleEvent?.Invoke(this);
        }

        public void RaiseTunnelEvent()
        {
            TunnelEvent?.Invoke(this);
        }

        public void OnBubbleEventHandler(object sender)
        {
            MessageBox.Show($"Bubble event invoked {Data}");
            Parent?.BubbleEvent?.Invoke(this);
        }

        public void OnTunnelEventHandler(object sender)
        {
            MessageBox.Show($"Tunnel event invoked {Data}");
            if (Children.Count() > 0)
            {
                foreach (var child in Children) child?.TunnelEvent(child);
            }
        }

        public void AddChild(Node child)
        {
            Children?.Add(child);
            if (child.Parent == null) child.Parent = this;
        }

        public string Data { get; set; }
        public Node Parent { get; set; }

        public ObservableCollection<Node> Children { get; set; } = new ObservableCollection<Node>();

    }

}
