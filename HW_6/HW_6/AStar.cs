using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6
{
    class AStarAlgorithm : IEnumerable<char>
    {
        MyHeap<Node> openNodes = new MyHeap<Node>();
        MyHeap<Node> closedNodes = new MyHeap<Node>();
        Node[] nodeArray;
        Node endNode;
        Node currentNode;

        public AStarAlgorithm(Node[] arr)
        {
            nodeArray = arr;
        }
        public void Traverse()
        {
            char startNodeName;
            char endNodeName;
            Console.Write("Enter Starting Node Letter: ");
            startNodeName = Console.ReadKey().KeyChar;
            Console.WriteLine();
            currentNode = findNodeInArray(startNodeName);
            Console.Write("Enter Ending Node Letter: ");
            endNodeName = Console.ReadKey().KeyChar;
            Console.WriteLine();
            endNode = findNodeInArray(endNodeName);

            ProcessNode(currentNode);
            while (!currentNode.Equals(endNode))
            {
                CheckConnections(currentNode);
                currentNode = PickNextNode(currentNode);
            }
        }

        private Node findNodeInArray(char target)
        {
            target = char.ToUpper(target);
            for (int i = 0; i < nodeArray.Length; i++)
            {
                if (nodeArray[i].Name.Equals(target))
                {
                    return nodeArray[i];
                }
            }
            return null;
        }
        private void ProcessNode(Node node, Node previous = null)
        {
            if (previous != null)
            {
                node.CostSoFar = previous.CostSoFar + DistanceFormula(node.Coordinates, previous.Coordinates);
                node.CameFrom = previous;
            }
            else
                node.CostSoFar = 0;

            node.Heuristic = DistanceFormula(node.Coordinates, endNode.Coordinates);
            node.TotalEstimatedCost = node.Heuristic + node.CostSoFar;
        }
        private double DistanceFormula(double[] a, double[] b)
        {
            return Math.Sqrt(Math.Pow((b[0]-a[0]),2) + Math.Pow((b[1] - a[1]), 2));
        }
        private Node PickNextNode(Node node)
        {
            closedNodes.Add(node);          
            return openNodes.PopTop();
        }
        private void CheckConnections(Node node)
        {
            for (int i = 1; i <= openNodes.Count; i++)
            {
                ProcessNode(openNodes[i], node);
            }
            foreach(Node connectingNode in node.Connections)
            {
                if (!closedNodes.Contains(connectingNode) && !openNodes.Contains(connectingNode))
                {
                    ProcessNode(connectingNode, node);
                    openNodes.Add(connectingNode);
                }
            }
        }
        public IEnumerator<char> GetEnumerator()
        {
            Node runnerNode = endNode;
            List<char> nodeOrder = new List<char>();
            while(runnerNode != null)
            {
                nodeOrder.Add(runnerNode.Name);
                runnerNode = runnerNode.CameFrom;
            }
            for(int i = nodeOrder.Count-1; i >= 0; i--)
            {
                yield return nodeOrder[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
