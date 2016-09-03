using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_5
{
    class BinarySearchTree<T> where T : IComparable<T>
    {
        IComparer<T> comparer;
        Node<T> runnerNode;
        int counter;
        public BinarySearchTree(IComparer<T> comparer = null)
        {
            rootNode = null;
            runnerNode = null;
            this.comparer = comparer;
            counter = 0;
        }

        public Node<T> rootNode { get; set; }
        public void AddItem(T item) 
        {
            Node<T> addedNode = new Node<T> { Value = item , leftChild = null, rightChild = null};

            if (rootNode == null)
            {
                rootNode = addedNode;
                runnerNode = rootNode;
            }
            else
            {
                runnerNode = rootNode;
                while (true)
                {
                    if (comparer != null)
                    {
                        if (comparer.Compare(item, runnerNode.Value) < 0)//item is less than Value
                        {
                            if (runnerNode.leftChild != null)
                                runnerNode = runnerNode.leftChild;
                            else 
                            {
                                runnerNode.leftChild = addedNode;
                                break;
                            }
                        }
                        else //item is greater than or equal to value 
                        {
                            if (runnerNode.rightChild != null)
                                runnerNode = runnerNode.rightChild;
                            else
                            {
                                runnerNode.rightChild = addedNode;
                                break;
                            }
                        }

                    }
                    else
                    {
                        if (item.CompareTo(runnerNode.Value) < 0) //item is less than Value
                        {
                            if (runnerNode.leftChild != null)
                                runnerNode = runnerNode.leftChild;
                            else
                            {
                                runnerNode.leftChild = addedNode;
                                break;
                            }
                        }
                        else //item is greater than or equal to Value 
                        {
                            if (runnerNode.rightChild != null)
                                runnerNode = runnerNode.rightChild;
                            else
                            {
                                runnerNode.rightChild = addedNode;
                                break;
                            }
                        }

                    }
                }
            }
            counter++;
        }
        public bool Contains(T item)
        {
            runnerNode = rootNode;
            while (runnerNode != null)
            {
                if (comparer != null)
                {
                    if (comparer.Compare(item, runnerNode.Value) < 0)
                    {
                        runnerNode = runnerNode.leftChild;
                    }
                    else if (comparer.Compare(item, runnerNode.Value) > 0)
                    {
                        runnerNode = runnerNode.rightChild;
                    }
                    else{
                        return true;
                    }
                }
                else
                {
                    if(item.CompareTo(runnerNode.Value) < 0)
                    {
                        runnerNode = runnerNode.leftChild;
                    }
                    else if (item.CompareTo(runnerNode.Value) > 0)
                    {
                        runnerNode = runnerNode.rightChild;
                    }
                    else
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        public string TraversePreV2(Node<T> node)
        {
            string traversalOrder = "";
            traversalOrder += node.Value.ToString() + " ";
            if (node.leftChild != null)
                traversalOrder += TraversePreV2(node.leftChild);
            if (node.rightChild != null)
                traversalOrder += TraversePreV2(node.rightChild);
            return traversalOrder;
        }
        public string TraverseInV2(Node<T> node)
        {
            string traversalOrder = ""; 
            if (node.leftChild != null)
                traversalOrder += TraverseInV2(node.leftChild);

            traversalOrder += node.Value.ToString() + " ";

            if (node.rightChild != null)
                traversalOrder += TraverseInV2(node.rightChild);
            return traversalOrder;
        }
        public string TraversePostV2(Node<T> node)
        {
            string traversalOrder = "";
            if (node.leftChild != null)
                traversalOrder += TraversePostV2(node.leftChild);
            if (node.rightChild != null)
                traversalOrder += TraversePostV2(node.rightChild);
            traversalOrder += node.Value.ToString() + " ";
            return traversalOrder;
        }


        public string TraversePre() //root, left, then right
        {
            string returnedString = "";
            IEnumerator<T> treeTraversal = rootNode.TraversePre();
            while (treeTraversal.MoveNext())
            {
                returnedString += treeTraversal.Current + " "; 
            }
            return returnedString;
        }
        public string TraverseIn() //left, root, right
        {
            string returnedString = "";
            IEnumerator<T> treeTraversal = rootNode.TraverseIn();
            while (treeTraversal.MoveNext())
            {
                returnedString += treeTraversal.Current + " ";
            }
            return returnedString;
        }
        public string TraversePost() //left, right, root
        {
            string returnedString = "";
            IEnumerator<T> treeTraversal = rootNode.TraversePost();
            while (treeTraversal.MoveNext())
            {
                returnedString += treeTraversal.Current + " ";
            }
            return returnedString;
        }
    }
}
