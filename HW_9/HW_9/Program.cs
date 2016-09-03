using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9
{
    class Program
    {
       static void Main(string[] args)
       {
            
            TestPopTop();
            TestHeapSort();

            Random rand = new Random();

            Console.WriteLine("======| Testing Invariants of Heaps|======");
            Console.WriteLine();
            MyHeap<int> heap1 = new MyHeap<int>();
            for (int i = 0; i < 1000; i++)
            {
                heap1.Add(rand.Next(1,1500));
            }
            TestInvariants(heap1);
            Console.WriteLine();

            MyHeap<int> heap2 = new MyHeap<int>();
            for (int i = 0; i < 10000; i++)
            {
                heap2.Add(rand.Next(-30000, 30000));
            }
            TestInvariants(heap2);
            Console.WriteLine();

            for (int i = 0; i < rand.Next(300, 700); i++)
            {
                heap1.PopTop();
            }
            TestInvariants(heap1);
            Console.WriteLine();
            for (int i = 0; i < 10000; i++)
            {
                heap2.PopTop();
            }
            TestInvariants(heap2);
            Console.ReadLine();
       }
       static void TestPopTop()
       {
            Console.WriteLine("======| Testing Adding and PopTop |======");
            Console.WriteLine();
            MyHeap<int> heap = new MyHeap<int>();
            int previousVal, currentVal;

            heap.Add(10); Console.WriteLine("Adding 10 to the heap...");
            heap.Add(21); Console.WriteLine("Adding 21 to the heap...");
            heap.Add(1); Console.WriteLine("Adding 1 to the heap...");
            heap.Add(33); Console.WriteLine("Adding 33 to the heap...");
            heap.Add(13); Console.WriteLine("Adding 13 to the heap...");
            heap.Add(55); Console.WriteLine("Adding 55 to the heap...");
            heap.Add(2); Console.WriteLine("Adding 2 to the heap...");
            heap.Add(0); Console.WriteLine("Adding 0 to the heap...");
            heap.Add(77); Console.WriteLine("Adding 77 to the heap...");
            heap.Add(67); Console.WriteLine("Adding 67 to the heap...");
            heap.Add(22); Console.WriteLine("Adding 22 to the heap...");

            previousVal = heap.PopTop();
            while (heap.Count > 0)
            {
                currentVal = heap.PopTop(); 
                Debug.Assert(currentVal < previousVal); Console.WriteLine("Current popped value of " + currentVal + " is less than the previous popped value of " + previousVal);
                previousVal = currentVal;
            }
            Console.WriteLine();
        }
        static void TestRemove()
        {
            MyHeap<int> heap = new MyHeap<int>();

            heap.Add(10); Console.WriteLine("Adding 10 to the heap...");
            heap.Add(21); Console.WriteLine("Adding 21 to the heap...");
            heap.Add(1); Console.WriteLine("Adding 1 to the heap...");
            heap.Add(33); Console.WriteLine("Adding 33 to the heap...");
            heap.Add(13); Console.WriteLine("Adding 13 to the heap...");
            heap.Add(55); Console.WriteLine("Adding 55 to the heap...");
            heap.Add(2); Console.WriteLine("Adding 2 to the heap...");
            heap.Add(0); Console.WriteLine("Adding 0 to the heap...");
            heap.Add(77); Console.WriteLine("Adding 77 to the heap...");
            heap.Add(67); Console.WriteLine("Adding 67 to the heap...");
            heap.Add(22); Console.WriteLine("Adding 22 to the heap...");

            Console.WriteLine(heap.ToString());
            heap.Remove(13);
            Console.WriteLine(heap.ToString());

        }
        /*static void TestComparer()
        {
            Console.WriteLine("======| Testing Heap Comparer |======");
            MyHeap<Person> heap = new MyHeap<Person>();
            heap.Add(10); Console.WriteLine("Adding 10 to the heap...");

       
        }*/
        static void TestHeapSort()
        {
            Console.WriteLine("======| Testing Heap Sort |======");
            MyHeap<int> heap = new MyHeap<int>();
            heap.Add(10); Console.WriteLine("Adding 10 to the heap...");
            heap.Add(22); Console.WriteLine("Adding 22 to the heap...");
            heap.Add(39); Console.WriteLine("Adding 39 to the heap...");
            heap.Add(2); Console.WriteLine("Adding 2 to the heap...");
            heap.Add(87); Console.WriteLine("Adding 87 to the heap...");
            heap.Add(0); Console.WriteLine("Adding 0 to the heap...");
            heap.Add(1); Console.WriteLine("Adding 1 to the heap...");
            heap.Add(49); Console.WriteLine("Adding 49 to the heap...");
            heap.Add(66); Console.WriteLine("Adding 66 to the heap...");
            heap.Add(11); Console.WriteLine("Adding 11 to the heap...");

            Console.WriteLine();
            heap.Sort(); Console.WriteLine("Sorting heap...");
            Console.WriteLine();

            for (int i = 1; i < heap.Count-1; i++)
            {
                Debug.Assert(heap[i] < heap[i + 1]); Console.WriteLine("previous value of " + heap[i] + " is less than current value of " + heap[i + 1]);
            }
            Console.WriteLine();
        }
        static void TestInvariants(MyHeap<int> aHeap)
        {
            Console.WriteLine("Testing heaps invariants...");
            for (int i = 1; i < aHeap.Count/2; i++)
            {
                Debug.Assert(aHeap[i].CompareTo(aHeap[i*2]) >= 0); //checking left child is less than parent
                if((i*2) + 1 < aHeap.Count)
                    Debug.Assert(aHeap[i].CompareTo(aHeap[(i * 2) + 1]) >= 0); //checking right child is less than parent
            }
            Debug.Assert(aHeap.Count == aHeap.underlyingList.Count - 1); //Checking that all values of the list are filled
            Console.WriteLine("All invariants satisfied");
        }
    }
    class Person : IComparable<Person>
    {
        public int Age { get; set; }
        public int Height { get; set; }
        public Person()
        {

        }

        public int CompareTo(Person other)
        {
            throw new NotImplementedException();
        }
    }
    class PeopleComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if(x.Age > y.Age)
            {
                return 1;
            }
            else if(x.Age < y.Age)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
