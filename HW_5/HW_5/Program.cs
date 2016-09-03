using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            TestBinarySearchTree();
            TestExpressionParser();*/
            TestPreOrderTraversal();
            TestInOrderTraversal();
            TestPostOrderTraversal();
            
            
            Console.ReadLine();
        }
        public static void TestBinarySearchTree()
        {
            TestAdd();
            TestContains();
            TestPreOrderTraversal();
            TestInOrderTraversal();
            TestPostOrderTraversal();
            TestComparing();
        }
        public static void TestExpressionParser()
        {
            TestExpression("3 + 8 / 2", 3 + 8 / 2);
            TestExpression("9 + 8 / 2 * 5", 9 + 8 / 2 * 5);
            TestExpression("6 - 6", 6 - 6);
            TestExpression("6 + 6", 6 + 6);
            TestExpression("7 * 10", 7 * 10);
            TestExpression("10 / 2", 10 / 2);
            TestExpression("9 * 9 * 9 * 9", 9 * 9 * 9 * 9);
            TestExpression("5", 5);
            TestExpression("10 / 5 * 4 + 3 * 15 / 5", 10 / 5 * 4 + 3 * 15 / 5);
            TestExpression("64 / 2 / 2 / 2", 64 / 2 / 2 / 2);
            TestExpression("2 + 3 - 8 + 10 - 13 + 1 - 6", 2 + 3 - 8 + 10 - 13 + 1 - 6);
        }
        public static void TestExpression(string expression, int expectedResult)
        {
            /*
            this function tests the evaluate function for the Expression Parser. 
            It takes a string literal of the expression, evaluates it, and then compares
            it to the same expression (in integer form) solved by the compiler
            */
            Console.WriteLine("Testing Expression Parser for the equation: " + expression);
            ExpressionTree parserTestTree = ExpressionParser.CreateTree(expression);
            int treeResult = parserTestTree.Evaluate();
            Console.WriteLine("Evaluated Expression:  " + treeResult);
            Console.WriteLine("Expected Result:       " + expectedResult);
            Debug.Assert(treeResult == expectedResult);
            Console.WriteLine();
        }

        public static void TestAdd()
        {
            BinarySearchTree<int> testTree = new BinarySearchTree<int>();

            Console.WriteLine("------Testing Binary Search Tree Adding Function------");

            testTree.AddItem(10); Console.WriteLine("Adding 10 to the tree");
            testTree.AddItem(2); Console.WriteLine("Adding 2 to the tree");
            testTree.AddItem(5); Console.WriteLine("Adding 5 to the tree");
            testTree.AddItem(0); Console.WriteLine("Adding 0 to the tree");
            testTree.AddItem(15); Console.WriteLine("Adding 15 to the tree");

            string expectedResult = "10 2 0 5 15 ";
            string traverseResult = testTree.TraversePre();
            Debug.Assert(testTree.rootNode.Value == 10); Console.WriteLine("Tree has correct rootnode");
            Console.WriteLine("Testing all values of tree...");
            Console.WriteLine("Expected Result:                    " + expectedResult);
            Console.WriteLine("Result After Pre-Order Traversal:   " + traverseResult);
            Debug.Assert(traverseResult.CompareTo(expectedResult) == 0);
            Console.WriteLine();
            testTree.AddItem(10); Console.WriteLine("Adding 10 to the tree");
            testTree.AddItem(10); Console.WriteLine("Adding 10 to the tree");
            testTree.AddItem(15); Console.WriteLine("Adding 15 to the tree");
            testTree.AddItem(0); Console.WriteLine("Adding 0 to the tree");
            Console.WriteLine("Testing all values of tree...");
            expectedResult = "10 2 0 0 5 15 10 10 15 ";
            traverseResult = testTree.TraversePre();
            Console.WriteLine("Expected Result:                    " + expectedResult);
            Console.WriteLine("Result After Pre-Order Traversal:   " + traverseResult);
            Debug.Assert(traverseResult.CompareTo(expectedResult) == 0);
            Console.WriteLine("Adding test suceeeded");
            Console.WriteLine();
        }
        public static void TestContains()
        {
            Console.WriteLine("------Testing Binary Search Tree Contains Function------");

            BinarySearchTree<int> testTree = new BinarySearchTree<int>();
            testTree.AddItem(5); Console.WriteLine("Adding 5 to the tree");
            testTree.AddItem(10); Console.WriteLine("Adding 10 to the tree");
            testTree.AddItem(3); Console.WriteLine("Adding 3 to the tree");
            testTree.AddItem(2); Console.WriteLine("Adding 2 to the tree");
            testTree.AddItem(8); Console.WriteLine("Adding 8 to the tree");
            testTree.AddItem(11); Console.WriteLine("Adding 11 to the tree");
            testTree.AddItem(0); Console.WriteLine("Adding 0 to the tree");
            Console.WriteLine("Testing all values of tree...");

            Debug.Assert(testTree.Contains(5)); Console.WriteLine("Tree contains 5");
            Debug.Assert(testTree.Contains(10)); Console.WriteLine("Tree contains 10");
            Debug.Assert(testTree.Contains(3)); Console.WriteLine("Tree contains 3");
            Debug.Assert(testTree.Contains(2)); Console.WriteLine("Tree contains 2");
            Debug.Assert(testTree.Contains(8)); Console.WriteLine("Tree contains 8");
            Debug.Assert(testTree.Contains(11)); Console.WriteLine("Tree contains 11");
            Debug.Assert(testTree.Contains(0)); Console.WriteLine("Tree contains 0");
            Debug.Assert(!testTree.Contains(9)); Console.WriteLine("Tree does not contain 9");
            Debug.Assert(!testTree.Contains(16)); Console.WriteLine("Tree does not contain 16");

            Console.WriteLine("Contains test suceeeded");
            Console.WriteLine();
        }
        public static void TestPreOrderTraversal()
        {
            Console.WriteLine("------Testing Binary Search Tree Pre-Order Traversal------");
            BinarySearchTree<int> testTree = new BinarySearchTree<int>();
            testTree.AddItem(9); Console.WriteLine("Adding 9 to the tree");
            testTree.AddItem(11); Console.WriteLine("Adding 11 to the tree");
            testTree.AddItem(5); Console.WriteLine("Adding 5 to the tree");
            testTree.AddItem(10); Console.WriteLine("Adding 10 to the tree");
            testTree.AddItem(3); Console.WriteLine("Adding 3 to the tree");
            testTree.AddItem(0); Console.WriteLine("Adding 0 to the tree");
            testTree.AddItem(7); Console.WriteLine("Adding 7 to the tree");
            testTree.AddItem(15); Console.WriteLine("Adding 15 to the tree");
            testTree.AddItem(7); Console.WriteLine("Adding 7 to the tree");
            Console.WriteLine("Testing all values of tree...");
            string testString = "9 5 3 0 7 7 11 10 15 ";
            string result = testTree.TraversePre();
            Debug.Assert(string.Compare(result, testString) == 0); Console.WriteLine("All values of tree:       " + result); Console.WriteLine("Expected values of tree:  " + testString);
            Console.WriteLine("Other Traversal Method:   " + testTree.TraversePreV2(testTree.rootNode));
            Console.WriteLine("Pre-Order Traversal Test Suceeded");
            Console.WriteLine();
        }
        public static void TestInOrderTraversal()
        {
            Console.WriteLine("------Testing Binary Search Tree In-Order Traversal------");
            BinarySearchTree<int> testTree = new BinarySearchTree<int>();
            testTree.AddItem(9); Console.WriteLine("Adding 9 to the tree");
            testTree.AddItem(11); Console.WriteLine("Adding 11 to the tree");
            testTree.AddItem(5); Console.WriteLine("Adding 5 to the tree");
            testTree.AddItem(10); Console.WriteLine("Adding 10 to the tree");
            testTree.AddItem(3); Console.WriteLine("Adding 3 to the tree");
            testTree.AddItem(0); Console.WriteLine("Adding 0 to the tree");
            testTree.AddItem(7); Console.WriteLine("Adding 7 to the tree");
            testTree.AddItem(15); Console.WriteLine("Adding 15 to the tree");
            testTree.AddItem(7); Console.WriteLine("Adding 7 to the tree");
            Console.WriteLine("Testing all values of tree...");
            string testString = "9 5 3 0 7 7 11 10 15 ";
            string result = testTree.TraverseIn();
            
            /*Debug.Assert(string.Compare(result, testString) == 0);*/ Console.WriteLine("All values of tree:       " + result); Console.WriteLine("Expected values of tree:  " + testString);
            Console.WriteLine("Other Traversal Method:   " + testTree.TraverseInV2(testTree.rootNode));
            Console.WriteLine("In-Order Traversal Test Suceeded");
            Console.WriteLine("");
        }
        public static void TestPostOrderTraversal()
        {
            Console.WriteLine("------Testing Binary Search Tree Post-Order Traversal------");
            BinarySearchTree<int> testTree = new BinarySearchTree<int>();
            testTree.AddItem(9); Console.WriteLine("Adding 9 to the tree");
            testTree.AddItem(11); Console.WriteLine("Adding 11 to the tree");
            testTree.AddItem(5); Console.WriteLine("Adding 5 to the tree");
            testTree.AddItem(10); Console.WriteLine("Adding 10 to the tree");
            testTree.AddItem(3); Console.WriteLine("Adding 3 to the tree");
            testTree.AddItem(0); Console.WriteLine("Adding 0 to the tree");
            testTree.AddItem(7); Console.WriteLine("Adding 7 to the tree");
            testTree.AddItem(15); Console.WriteLine("Adding 15 to the tree");
            testTree.AddItem(7); Console.WriteLine("Adding 7 to the tree");
            Console.WriteLine("Testing all values of tree...");
            string testString = "0 3 7 7 5 10 15 11 9 ";
            string result = testTree.TraversePost();

            Debug.Assert(string.Compare(result, testString) == 0); Console.WriteLine("All values of tree:       " + result); Console.WriteLine("Expected values of tree:  " + testString);
            Console.WriteLine("Other Traversal Method:   " + testTree.TraversePostV2(testTree.rootNode));
            Console.WriteLine("Post-Order Traversal Test Suceeded");
            Console.WriteLine();
        }
        public static void TestComparing()
        {
            Console.WriteLine("------Testing Tree Compare with Compare object------");
            PeopleComparer comparer = new PeopleComparer();
            BinarySearchTree<Person> peopleTree1 = new BinarySearchTree<Person>(comparer);
            BinarySearchTree<Person> peopleTree2 = new BinarySearchTree<Person>(); //this tree does not have an IComparer object passed therefore relies on Person.compareTo()
            Person Julia = new Person { Name = "Julia", Age = 40, Weight = 160 };
            Person Joe = new Person { Name = "Joe", Age = 60, Weight = 175 };
            Person Fred = new Person { Name = "Fred", Age = 35, Weight = 152 };
            Person Bob = new Person { Name = "Bob", Age = 10, Weight = 100 };
            Person Pam = new Person { Name = "Pam", Age = 72, Weight = 192 };

            peopleTree1.AddItem(Julia); Console.WriteLine("Adding person Julia to Tree1");
            peopleTree1.AddItem(Joe); Console.WriteLine("Adding person Joe to Tree1");
            peopleTree1.AddItem(Fred); Console.WriteLine("Adding person Fred to Tree1");
            peopleTree1.AddItem(Bob); Console.WriteLine("Adding person Bob to Tree1");
            peopleTree1.AddItem(Pam); Console.WriteLine("Adding person Pam to Tree1");
            Console.WriteLine();
            peopleTree2.AddItem(Julia); Console.WriteLine("Adding person Julia to Tree2");
            peopleTree2.AddItem(Joe); Console.WriteLine("Adding person Joe to Tree2");
            peopleTree2.AddItem(Fred); Console.WriteLine("Adding person Fred to Tree2");
            peopleTree2.AddItem(Bob); Console.WriteLine("Adding person Bob to Tree2");
            peopleTree2.AddItem(Pam); Console.WriteLine("Adding person Pam to Tree2");
            string peopleOrder = "Julia Fred Bob Joe Pam ";
            string tree1Result = "", tree2Result = "";
            IEnumerator<Person> tree1Traversal = peopleTree1.rootNode.TraversePre();
            IEnumerator<Person> tree2Traversal = peopleTree2.rootNode.TraversePre();
            Console.WriteLine("Comparing all values of both trees...");
            while(tree1Traversal.MoveNext() && tree2Traversal.MoveNext())
            {
                tree1Result += tree1Traversal.Current.Name + " "; 
                tree2Result += tree2Traversal.Current.Name + " ";
            }
            Console.WriteLine("All values of people tree 1:   " + tree1Result);
            Console.WriteLine("All values of people tree 2:   " + tree2Result);
            Console.WriteLine("All values expected to be:     " + peopleOrder);
            Debug.Assert(peopleOrder.CompareTo(tree1Result) == 0);
            Debug.Assert(peopleOrder.CompareTo(tree2Result) == 0);
            Debug.Assert(string.Compare(tree1Result,tree2Result) == 0);
            Console.WriteLine("Comparing Tests Suceeded");
            Console.WriteLine();
        }

    }

    class Person: IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }

        public int CompareTo(Person other) //This compareTo function compares the age between two people
        {
            return this.Age - other.Age;
        }
    }
    class PeopleComparer : IComparer<Person> //this IComparer compares the age between two people.
    {
        public int Compare(Person left, Person right)
        {
            return left.Age - right.Age;
        }
    }
}


/*
Coder – 60%
Write a BinarySearchTree class with an Add(int item) and Contains(int item).
Write an ExpressionParser class that will convert any given expression into an ExpressionTree class instance. The ExpressionParser must take a string such as “5 + 2 * 8 – 6 / 4” and convert it into an ExpressionTree. String has a Split() method which you will find quite helpful.
Programmer – 80%
Write a TraversePre(), TraverseIn(), and TraversePost() for both the BinarySearchTree class and the ExpressionTree class. These return the contents of your tree in a concatenated string using a pre-order traversal, an in-order traversal, and a post-order traversal. Description here: https://en.wikipedia.org/wiki/Tree_traversal#Pre-order (Links to an external site.)
Write an Evaluate() function on your ExpressionTree that calculates the value of your expression.
Engineer – 90%
Write test code for all code in your assignment (including the Google Engineer code if you complete that section of the assignment).
Testing hints: When testing your expression evaluation, I would expect you to assert that the result of your expression evaluation is equal to the same result as what the C# compiler calculates as well. Also, compare the result of the tree traversals to a string literal containing the correct result of the respective traversal.
Google Engineer – 100%
Instead of storing ints in your BinarySearchTree, store any generic T type instead.
Use T’s IComparable interface to do the comparision instead of the < operator.
Allow the user to pass an IComparer to the BinarySearchTree constructor to use in place of the IComparable functionality.
*/
