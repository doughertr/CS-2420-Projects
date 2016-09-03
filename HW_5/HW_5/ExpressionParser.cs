using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5
{
    static class ExpressionParser
    {
        public static ExpressionTree CreateTree(string formula)
        {
            ExpressionTree tree = new ExpressionTree();
            string[] formulaArray = formula.Split();
            int n, currentOperationNum = -1, previousOperationNum = -1;
            Node<string> leftChildOperand, rightChildOperand, parentOperator;
            Stack<Node<string>> operands = new Stack<Node<string>>();
            Stack<Node<string>> operators = new Stack<Node<string>>();

            for (int i = 0; i < formulaArray.Length; i++)
            {
                Node<string> newNode = new Node<string> { Value = formulaArray[i], leftChild = null, rightChild = null };

                if (int.TryParse(newNode.Value, out n)) // tests if the node's value is an integer or not
                    operands.Push(newNode);
                else
                {
                    switch (newNode.Value)
                    {
                        case "+":
                            currentOperationNum = 0;
                            break;
                        case "-":
                            currentOperationNum = 1;
                            break;
                        case "*":
                            currentOperationNum = 2;
                            break;
                        case "/":
                            currentOperationNum = 3;
                            break;
                        case "^":
                            currentOperationNum = 4;
                            break;
                    }

                    if (previousOperationNum == -1)
                        previousOperationNum = currentOperationNum;
                    else if (currentOperationNum <= previousOperationNum)
                    {
                        rightChildOperand = operands.Pop();
                        leftChildOperand = operands.Pop();

                        parentOperator = operators.Pop();

                        parentOperator.rightChild = rightChildOperand;
                        parentOperator.leftChild = leftChildOperand;

                        operands.Push(parentOperator);

                    }
                    previousOperationNum = currentOperationNum;
                    operators.Push(newNode);

                }
            }
            while (operators.Count > 0)
            {
                rightChildOperand = operands.Pop();
                leftChildOperand = operands.Pop();

                parentOperator = operators.Pop();

                parentOperator.rightChild = rightChildOperand;
                parentOperator.leftChild = leftChildOperand;

                operands.Push(parentOperator);
            }
            tree.rootNode = operands.Pop();
            return tree;
        }
    }
    class ExpressionTree
    {
        public Node<string> rootNode { get; set; }

        public string TraversePre() //root, left, then right
        {
            string returnedString = "";
            IEnumerator<string> treeTraversal = rootNode.TraversePre();
            while (treeTraversal.MoveNext())
            {
                returnedString += treeTraversal.Current + " ";
            }
            return returnedString;
        }
        public string TraverseIn() //left, root, right
        {
            string returnedString = "";
            IEnumerator<string> treeTraversal = rootNode.TraverseIn();
            while (treeTraversal.MoveNext())
            {
                returnedString += treeTraversal.Current + " ";
            }
            return returnedString;
        }
        public string TraversePost() //left, right, root
        {
            string returnedString = "";
            IEnumerator<string> treeTraversal = rootNode.TraversePost();
            while (treeTraversal.MoveNext())
            {
                returnedString += treeTraversal.Current + " ";
            }
            return returnedString;
        }

        public int Evaluate()
        {
            string traverseString = TraversePost();
            traverseString = traverseString.Substring(0, traverseString.Length - 1); //takes away the extra space at the end
            string[] nodeNames = traverseString.Split(' '); //splits the string up into an array of strings
            int result = 0, n;
            Stack <int> numberStack = new Stack<int>();

            for (int i = 0; i < nodeNames.Length; i++)
            {
                if (int.TryParse(nodeNames[i], out n))
                    numberStack.Push(int.Parse(nodeNames[i]));
                else
                {
                    int num1 = numberStack.Pop();
                    int num2 = numberStack.Pop();
                    switch(nodeNames[i])
                    {
                        case "^":
                            numberStack.Push((int)Math.Pow(num2, num1));
                            break;
                        case "*":
                            numberStack.Push(num2 * num1);
                            break;
                        case "/":
                            numberStack.Push(num2 / num1);
                            break;
                        case "+":
                            numberStack.Push(num2 + num1);
                            break;
                        case "-":
                            numberStack.Push(num2 - num1);
                            break;
                    }
                }
            }
            result = numberStack.Pop();
            return result;
        }
    }
}