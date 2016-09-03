using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node { Value = 55 };
            Node node1 = new Node { Value = 48 };
            Node node2 = new Node { Value = 35 };
            Node node3 = new Node { Value = 39 };
            Node node4 = new Node { Value = 22 };
            Node node5 = new Node { Value = 30 };
            Node node6 = new Node { Value = 34 };
            Node node7 = new Node { Value = 35 };
            Node node8 = new Node { Value = 8 };

            root.LeftChild = node2;
            root.RightChild = node1;
            node1.LeftChild = node3;
            node1.RightChild = node4;
            node2.LeftChild = node5;
            node2.RightChild = node6;
            node3.LeftChild = node7;
            node3.RightChild = node8;
            /*node4.LeftChild = null;
            node4.RightChild = ;
            node5.LeftChild = ;
            node5.RightChild = ;
            node6.LeftChild = ;
            node6.RightChild = ;
            node7.LeftChild = ;
            node7.RightChild = ;
            node8.LeftChild = ;
            node8.RightChild = ;*/
        }
    }
}
