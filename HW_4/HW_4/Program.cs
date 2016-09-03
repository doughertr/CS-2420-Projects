using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

//assertion is Debug.Assert(condition)

namespace HW_4
{
    interface IsSorter
    {
        void Sort(int[] arr);
    }

    class MainCode
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            TestList();
            TestSorts();
            //sorterRunningTimes();
            //TestListRunningTimes();
            Console.ReadLine();
        }
        static void TestList()
        {
            TestAdd();
            TestEnumerate();
            TestEnumerateCompiler();
            TestClear();
            TestInsert();
            TestContains();
            TestIndexOf();
            TestIndexer();
            TestRemove();
        }
        static void TestSorts()
        {
            TestInsertionSort();
            TestSelectionSort();
            TestQuickSort();
            TestMergeSort();
            TestBubbleSort();
        }

        public static void TestMergeSort()
        {
            Console.WriteLine("------Testing Merge Sort------");
            MergeSort sorter = new MergeSort();
            int[] arr1 = { 1, 2, 3, 4, 5 };
            int[] sortedArr1 = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr1));
            sorter.Sort(arr1);
            Debug.Assert(arr1.SequenceEqual(sortedArr1));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr1));
            int[] arr2 = { 5, 4, 3, 2, 1 };
            int[] sortedArr2 = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr2));
            sorter.Sort(arr2);
            Debug.Assert(arr2.SequenceEqual(sortedArr2));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr2));
            int[] arr3 = { 7, 1, 9, 3 };
            int[] sortedArr3 = { 1, 3, 7, 9 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr3));
            sorter.Sort(arr3);
            Debug.Assert(arr3.SequenceEqual(sortedArr3));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr3));
            int[] arr4 = { };
            int[] sortedArr4 = { };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr4));
            sorter.Sort(arr4);
            Debug.Assert(arr4.SequenceEqual(sortedArr4));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr4));
            int[] arr5 = { 1, 1, 1, 1 };
            int[] sortedArr5 = { 1, 1, 1, 1 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr5));
            sorter.Sort(arr5);
            Debug.Assert(arr5.SequenceEqual(sortedArr5));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr5));
            Console.WriteLine();
        }

        public static void TestBubbleSort()
        {
            Console.WriteLine("------Testing Bubble Sort------");
            BubbleSort sorter = new BubbleSort();

            int[] arr1 = { 1, 2, 3, 4, 5 };
            int[] sortedArr1 = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr1));
            sorter.Sort(arr1);
            Debug.Assert(arr1.SequenceEqual(sortedArr1));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr1));
            int[] arr2 = { 5, 4, 3, 2, 1 };
            int[] sortedArr2 = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr2));
            sorter.Sort(arr2);
            Debug.Assert(arr2.SequenceEqual(sortedArr2));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr2));
            int[] arr3 = { 7, 1, 9, 3 };
            int[] sortedArr3 = { 1, 3, 7, 9 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr3));
            sorter.Sort(arr3);
            Debug.Assert(arr3.SequenceEqual(sortedArr3));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr3));
            int[] arr4 = { };
            int[] sortedArr4 = { };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr4));
            sorter.Sort(arr4);
            Debug.Assert(arr4.SequenceEqual(sortedArr4));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr4));
            int[] arr5 = { 1, 1, 1, 1 };
            int[] sortedArr5 = { 1, 1, 1, 1 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr5));
            sorter.Sort(arr5);
            Debug.Assert(arr5.SequenceEqual(sortedArr5));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr5));
            Console.WriteLine();
        }

        public static void TestQuickSort()
        {
            Console.WriteLine("------Testing Quick Sort------");
            QuickSort sorter = new QuickSort();
            int[] arr1 = { 1, 2, 3, 4, 5 };
            int[] sortedArr1 = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr1));
            sorter.Sort(arr1);
            Debug.Assert(arr1.SequenceEqual(sortedArr1));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr1));
            int[] arr2 = { 5, 4, 3, 2, 1 };
            int[] sortedArr2 = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr2));
            sorter.Sort(arr2);
            Debug.Assert(arr2.SequenceEqual(sortedArr2));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr2));
            int[] arr3 = { 7, 1, 9, 3 };
            int[] sortedArr3 = { 1, 3, 7, 9 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr3));
            sorter.Sort(arr3);
            Debug.Assert(arr3.SequenceEqual(sortedArr3));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr3));
            int[] arr4 = { };
            int[] sortedArr4 = { };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr4));
            sorter.Sort(arr4);
            Debug.Assert(arr4.SequenceEqual(sortedArr4));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr4));
            int[] arr5 = { 1, 1, 1, 1 };
            int[] sortedArr5 = { 1, 1, 1, 1 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr5));
            sorter.Sort(arr5);
            Debug.Assert(arr5.SequenceEqual(sortedArr5));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr5));
            Console.WriteLine();
        }

        public static void TestSelectionSort()
        {
            Console.WriteLine("------Testing Selection Sort------");
            SelectionSort sorter = new SelectionSort();

            int[] arr1 = { 1, 2, 3, 4, 5 };
            int[] sortedArr1 = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr1));
            sorter.Sort(arr1);
            Debug.Assert(arr1.SequenceEqual(sortedArr1));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr1));
            int[] arr2 = { 5, 4, 3, 2, 1 };
            int[] sortedArr2 = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr2));
            sorter.Sort(arr2);
            Debug.Assert(arr2.SequenceEqual(sortedArr2));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr2));
            int[] arr3 = { 7, 1, 9, 3 };
            int[] sortedArr3 = { 1, 3, 7, 9 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr3));
            sorter.Sort(arr3);
            Debug.Assert(arr3.SequenceEqual(sortedArr3));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr3));
            int[] arr4 = { };
            int[] sortedArr4 = { };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr4));
            sorter.Sort(arr4);
            Debug.Assert(arr4.SequenceEqual(sortedArr4));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr4));
            int[] arr5 = { 1, 1, 1, 1 };
            int[] sortedArr5 = { 1, 1, 1, 1 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr5));
            sorter.Sort(arr5);
            Debug.Assert(arr5.SequenceEqual(sortedArr5));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr5));
            Console.WriteLine();
        }

        public static void TestInsertionSort()
        {
            Console.WriteLine("------Testing Insertion Sort------");
            InsertionSort sorter = new InsertionSort();

            int[] arr1 = { 1, 2, 3, 4, 5 };
            int[] sortedArr1 = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr1));
            sorter.Sort(arr1);
            Debug.Assert(arr1.SequenceEqual(sortedArr1));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr1));
            int[] arr2 = { 5, 4, 3, 2, 1 };
            int[] sortedArr2 = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr2));
            sorter.Sort(arr2);
            Debug.Assert(arr2.SequenceEqual(sortedArr2));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr2));
            int[] arr3 = { 7, 1, 9, 3 };
            int[] sortedArr3 = { 1, 3, 7, 9 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr3));
            sorter.Sort(arr3);
            Debug.Assert(arr3.SequenceEqual(sortedArr3));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr3));
            int[] arr4 = { };
            int[] sortedArr4 = { };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr4));
            sorter.Sort(arr4);
            Debug.Assert(arr4.SequenceEqual(sortedArr4));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr4));
            int[] arr5 = { 1, 1, 1, 1 };
            int[] sortedArr5 = { 1, 1, 1, 1 };
            Console.WriteLine("Sorting array: " + "[{0}]", string.Join(", ", arr5));
            sorter.Sort(arr5);
            Debug.Assert(arr5.SequenceEqual(sortedArr5));
            Console.WriteLine("Array now equals: " + "[{0}]", string.Join(", ", arr5));
            Console.WriteLine();
        }

        static void EnumerateAndAssert<T>(List<T> lis, T[] testArr)
        /*
        this function enumerates through the passed list and checks if
        each value in the list is equal to the passed test array
        */
        {
            Console.Write("List is equal to: ");
            int index = 0;
            IEnumerator lisEnumerator = lis.GetEnumerator();
            while (lisEnumerator.MoveNext())
            {
                Debug.Assert(lisEnumerator.Current.Equals(testArr[index]));
                Console.Write(lisEnumerator.Current + ", ");
                index++;
            }
            Debug.Assert(index == lis.Count);
            Console.WriteLine();
        }
        
        static void TestAdd()
        {
            Console.WriteLine("------Testing List Adding Function------");
            List<int> lis1 = new List<int>();
            lis1.Add(10); Console.WriteLine("adding 10 to the list");
            lis1.Add(5); Console.WriteLine("adding 5 to the list");
            lis1.Add(9); Console.WriteLine("adding 9 to the list");
            lis1.Add(9); Console.WriteLine("adding 9 to the list");
            lis1.Add(9); Console.WriteLine("adding 9 to the list");
            int[] testArr1 = { 10, 5 , 9 , 9 , 9};
            EnumerateAndAssert(lis1, testArr1);
            Console.WriteLine();

        }
        static void TestEnumerate()
        {
            Console.WriteLine("------Testing List Enumerate Function------");
            List<int> lis = new List<int>();
            lis.Add(1); Console.WriteLine("adding 1 to the list");
            lis.Add(2); Console.WriteLine("adding 2 to the list");
            lis.Add(3); Console.WriteLine("adding 3 to the list");
            lis.Add(4); Console.WriteLine("adding 4 to the list");
            lis.Add(5); Console.WriteLine("adding 5 to the list");
            lis.Add(6); Console.WriteLine("adding 6 to the list");
            int[] testArr = { 1, 2, 3, 4, 5, 6 };
            int index = 0;
            IEnumerator lisEnumerator = lis.GetEnumeratorNoYield();
            while (lisEnumerator.MoveNext() == true)
            {
                Debug.Assert(lisEnumerator.Current.Equals(testArr[index]));
                Console.WriteLine("List's current value: " + testArr[index] + " | " + "Enumerator's current value: " + lisEnumerator.Current );
                index++;
            }
            Debug.Assert(index == lis.Count);
            Console.WriteLine();
        }
        static void TestEnumerateCompiler()
        {
            Console.WriteLine("------Testing List Compiler Enumerate Function------");
            List<int> lis = new List<int>();
            lis.Add(1); Console.WriteLine("adding 1 to the list");
            lis.Add(2); Console.WriteLine("adding 2 to the list");
            lis.Add(3); Console.WriteLine("adding 3 to the list");
            lis.Add(4); Console.WriteLine("adding 4 to the list");
            lis.Add(5); Console.WriteLine("adding 5 to the list");
            lis.Add(6); Console.WriteLine("adding 6 to the list");
            int[] testArr = { 1, 2, 3, 4, 5, 6 };

            int index = 0;
            IEnumerator lisEnumerator = lis.GetEnumeratorCompiler();
            while (lisEnumerator.MoveNext())
            {
                Debug.Assert(lisEnumerator.Current.Equals(testArr[index]));
                Console.WriteLine("List's current value: " + testArr[index] + " | " + "Enumerator's current value: " + lisEnumerator.Current);
                index++;
            }
            Debug.Assert(index == lis.Count);
            Console.WriteLine();
        }
        static void TestInsert()
        {
            Console.WriteLine("------Testing List Insert Function------");
            List<int> lis1 = new List<int>();
            //inserting at the beginning of a list
            lis1.Insert(0, 6); Console.WriteLine("Inserting 6 to the list at position 0");
            lis1.Insert(0, 5); Console.WriteLine("Inserting 5 to the list at position 0");
            lis1.Insert(0, 4); Console.WriteLine("Inserting 4 to the list at position 0");
            lis1.Insert(0, 3); Console.WriteLine("Inserting 3 to the list at position 0");
            lis1.Insert(0, 2); Console.WriteLine("Inserting 2 to the list at position 0");
            lis1.Insert(0, 1); Console.WriteLine("Inserting 1 to the list at position 0");
            int[] testArr1 = { 1,2,3,4,5,6};
            EnumerateAndAssert(lis1, testArr1);

            //inserting at the end of a list 
            lis1.Insert(5, 7); Console.WriteLine("Inserting 7 to the list at position 5");
            lis1.Insert(6, 8); Console.WriteLine("Inserting 8 to the list at position 6");
            int[] testArr2 = { 1, 2, 3, 4, 5, 7, 8, 6 };
            EnumerateAndAssert(lis1, testArr2);

            //inserting at other positions in a list
            lis1.Insert(3, 50); Console.WriteLine("Inserting 50 to the list at position 3");
            lis1.Insert(7, 75); Console.WriteLine("Inserting 75 to the list at position 7");
            int[] testArr3 = { 1, 2, 3, 50, 4, 5, 7, 75, 8, 6 };
            EnumerateAndAssert(lis1, testArr3);
            Console.WriteLine();
        }
        static void TestRemove()
        {
            Console.WriteLine("------Testing List Remove Function------");
            List<int> lis1 = new List<int>();
            //testing remove for various items in the list
            lis1.Add(1); Console.WriteLine("adding 1 to the list");
            lis1.Add(2); Console.WriteLine("adding 2 to the list");
            lis1.Add(3); Console.WriteLine("adding 3 to the list");
            lis1.Add(4); Console.WriteLine("adding 4 to the list");
            lis1.Add(5); Console.WriteLine("adding 5 to the list");
            
            lis1.Remove(1); Console.WriteLine("removing 1 from the list");
            lis1.Remove(5); Console.WriteLine("removing 5 from the list");
            lis1.Remove(3); Console.WriteLine("removing 3 from the list");
            int[] testArr1 = { 2, 4 };
            EnumerateAndAssert(lis1, testArr1);

            //testing removeAt for 1st index, last index, and other index
            lis1.Add(6); Console.WriteLine("adding 6 to the list");
            lis1.Add(8); Console.WriteLine("adding 8 to the list");
            lis1.Add(10); Console.WriteLine("adding 10 to the list");

            lis1.RemoveAt(0); Console.WriteLine("removing at position 0 in the list");
            lis1.RemoveAt(lis1.Count-1); Console.WriteLine("removing at last position in the list");
            lis1.RemoveAt(1); Console.WriteLine("removing at position 1 in the list");
            int[] testArr2 = { 4, 8 };
            EnumerateAndAssert(lis1, testArr2);
            Console.WriteLine();
        }
        static void TestClear()
        {
            Console.WriteLine("------Testing List Clear Function------");
            //testing clear method
            List<int> lis1 = new List<int>();
            lis1.Add(1); Console.WriteLine("adding 1 to the list");
            lis1.Add(2); Console.WriteLine("adding 2 to the list");
            lis1.Add(3); Console.WriteLine("adding 3 to the list");
            lis1.Clear(); Console.WriteLine("clearing the list");
            Debug.Assert(lis1.Count == 0);
            lis1.Add(1); Console.WriteLine("adding 1 to the list");
            int[] testArr1 = { 1};
            EnumerateAndAssert(lis1, testArr1);
            Console.WriteLine();
        }
        static void TestIndexer()
        {
            Console.WriteLine("------Testing List Indexer Function------");
            //testing indexer getter and setter
            List<int> lis1 = new List<int>();
            lis1.Add(1); Console.WriteLine("adding 1 to the list");
            lis1.Add(2); Console.WriteLine("adding 2 to the list");
            lis1.Add(3); Console.WriteLine("adding 3 to the list");
            lis1[0] = 5; Console.WriteLine("setting position 0 to a value of 5");
            lis1[1] = 4; Console.WriteLine("setting position 1 to a value of 4");
            lis1[2] = 3; Console.WriteLine("setting position 2 to a value of 3");
            int[] testArr1 = { 5,4,3};

            EnumerateAndAssert(lis1, testArr1);
            Console.WriteLine();
        }
        static void TestContains()
        {
            Console.WriteLine("------Testing List Contains Function------");
            //testing contains method
            List<int> lis1 = new List<int>();
            lis1.Add(1); Console.WriteLine("adding 1 to the list");
            lis1.Add(2); Console.WriteLine("adding 2 to the list");
            lis1.Add(3); Console.WriteLine("adding 3 to the list");

            Debug.Assert(lis1.Contains(1)); Console.WriteLine("list does contain 1");
            Debug.Assert(lis1.Contains(2)); Console.WriteLine("list does contain 2");
            Debug.Assert(lis1.Contains(3)); Console.WriteLine("list does contain 3");
            Debug.Assert(!lis1.Contains(4)); Console.WriteLine("list does not contain 4");
            Console.WriteLine();
        }
        static void TestIndexOf()
        {
            Console.WriteLine("------Testing List InexOf Function------");
            //testing indexOf method
            List<int> lis1 = new List<int>();
            lis1.Add(1); Console.WriteLine("adding 1 to the list");
            lis1.Add(2); Console.WriteLine("adding 2 to the list");
            lis1.Add(3); Console.WriteLine("adding 3 to the list");
            lis1.Add(3); Console.WriteLine("adding 3 to the list");

            Debug.Assert(lis1.IndexOf(1) == 0); Console.WriteLine("index of 1 is element 0");
            Debug.Assert(lis1.IndexOf(2) == 1); Console.WriteLine("index of 2 is element 1");
            Debug.Assert(lis1.IndexOf(3) == 2); Console.WriteLine("index of 3 is element 2");
            Console.WriteLine();
        }
        static void sorterRunningTimes()
        {
            Console.WriteLine("Testing Running times for each sort...");
            Console.WriteLine();
            InsertionSortRunningTime();
            SelectionSortRunningTime();
            QuickSortRunningTime();
            MergeSortRunningTime();
            BubbleSortRunningTime();
        }
        static void InsertionSortRunningTime()
        {
            Stopwatch watch = new Stopwatch();
            Random rand = new Random();
            InsertionSort sort = new InsertionSort();

            Console.WriteLine("----Insertion Sort----");
            int[] arr1 = new int[1000];
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr1);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 1000: " + watch.ElapsedTicks);
            watch.Reset();

            int[] arr2 = new int[5000];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr2);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 5000: " + watch.ElapsedTicks);
            watch.Reset();

            int[] arr3 = new int[10000];
            for (int i = 0; i < arr3.Length; i++)
            {
                arr3[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr3);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 10000: " + watch.ElapsedTicks);
            watch.Reset();


            int[] arr4 = new int[50000];
            for (int i = 0; i < arr4.Length; i++)
            {
                arr4[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr4);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 50000: " + watch.ElapsedTicks);
            watch.Reset();

            Console.WriteLine();
        }
        static void SelectionSortRunningTime()
        {
            Stopwatch watch = new Stopwatch();
            Random rand = new Random();
            SelectionSort sort = new SelectionSort();

            Console.WriteLine("----Selection Sort----");
            int[] arr1 = new int[1000];
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr1);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 1000: " + watch.ElapsedTicks);
            watch.Reset();

            int[] arr2 = new int[5000];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr2);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 5000: " + watch.ElapsedTicks);
            watch.Reset();

            int[] arr3 = new int[10000];
            for (int i = 0; i < arr3.Length; i++)
            {
                arr3[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr3);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 10000: " + watch.ElapsedTicks);
            watch.Reset();


            int[] arr4 = new int[50000];
            for (int i = 0; i < arr4.Length; i++)
            {
                arr4[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr4);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 50000: " + watch.ElapsedTicks);
            watch.Reset();

            Console.WriteLine();
        }
        static void QuickSortRunningTime()
        {
            Stopwatch watch = new Stopwatch();
            Random rand = new Random();
            QuickSort sort = new QuickSort();

            Console.WriteLine("----Quick Sort----");
            int[] arr1 = new int[1000];
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr1);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 1000: " + watch.ElapsedTicks);
            watch.Reset();

            int[] arr2 = new int[5000];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr2);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 5000: " + watch.ElapsedTicks);
            watch.Reset();

            int[] arr3 = new int[10000];
            for (int i = 0; i < arr3.Length; i++)
            {
                arr3[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr3);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 10000: " + watch.ElapsedTicks);
            watch.Reset();


            int[] arr4 = new int[50000];
            for (int i = 0; i < arr4.Length; i++)
            {
                arr4[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr4);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 50000: " + watch.ElapsedTicks);
            watch.Reset();

            Console.WriteLine();
        }
        static void BubbleSortRunningTime()
        {
            Stopwatch watch = new Stopwatch();
            Random rand = new Random();
            BubbleSort sort = new BubbleSort();

            Console.WriteLine("----Bubble Sort----");
            int[] arr1 = new int[1000];
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr1);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 1000: " + watch.ElapsedTicks);
            watch.Reset();

            int[] arr2 = new int[5000];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr2);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 5000: " + watch.ElapsedTicks);
            watch.Reset();

            int[] arr3 = new int[10000];
            for (int i = 0; i < arr3.Length; i++)
            {
                arr3[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr3);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 10000: " + watch.ElapsedTicks);
            watch.Reset();


            int[] arr4 = new int[50000];
            for (int i = 0; i < arr4.Length; i++)
            {
                arr4[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr4);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 50000: " + watch.ElapsedTicks);
            watch.Reset();

            Console.WriteLine();
        }
        static void MergeSortRunningTime()
        {
            Stopwatch watch = new Stopwatch();
            Random rand = new Random();
            MergeSort sort = new MergeSort();

            Console.WriteLine("----Merge Sort----");
            int[] arr1 = new int[1000];
            for(int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = rand.Next(1, 11);
            }
            
            watch.Start();
            sort.Sort(arr1);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 1000: " + watch.ElapsedTicks);
            watch.Reset();

            int[] arr2 = new int[5000];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr2);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 5000: " + watch.ElapsedTicks);
            watch.Reset();

            int[] arr3 = new int[10000];
            for (int i = 0; i < arr3.Length; i++)
            {
                arr3[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr3);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 10000: " + watch.ElapsedTicks);
            watch.Reset();
            

            int[] arr4 = new int[50000];
            for (int i = 0; i < arr4.Length; i++)
            {
                arr4[i] = rand.Next(1, 11);
            }

            watch.Start();
            sort.Sort(arr4);
            watch.Stop();
            Console.WriteLine("Time taken to sort array length of 50000: " + watch.ElapsedTicks);
            watch.Reset();

            Console.WriteLine();
        }
        static void TestListRunningTimes()
        {
            TestListMethodRunningTime(0);
            TestListMethodRunningTime(1);
            TestListMethodRunningTime(2);
            TestListMethodRunningTime(3);
            TestListMethodRunningTime(4);
            TestListMethodRunningTime(5);
            TestListMethodRunningTime(6);
            TestListMethodRunningTime(7);
            TestListMethodRunningTime(8);
            /*
            TestIndexerRunningTime();
            TestCountRunningTime();
            TestClearRunningTime();
            TestContainsRunningTime();
            TestCopyToTunningTime();
            TestInsertRunningTime();
            TestRemoveRunningTime();
            TestRemoveAtRunningTime();
            */
        }

        private static void TestListMethodRunningTime(int methodNumber)
        {
            Stopwatch watch = new Stopwatch();
            Random rand = new Random();
            List<int> lis1 = new List<int>();
            List<int> lis2 = new List<int>();
            List<int> lis3 = new List<int>();
            List<int> lis4 = new List<int>();

            for (int i = 0; i < 1000; i++)
            {
                lis1.Add(rand.Next(1, 11));
            }
            for (int i = 0; i < 5000; i++)
            {
                lis2.Add(rand.Next(1, 11));
            }
            for (int i = 0; i < 10000; i++)
            {
                lis3.Add(rand.Next(1, 11));
            }
            for (int i = 0; i < 50000; i++)
            {
                lis4.Add(rand.Next(1, 11));
            }

            switch (methodNumber)
            {
                case 0:
                    //Runtime for Add Method
                    Console.WriteLine("----List.Add()----");

                    watch.Start();
                    lis1.Add(0);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 1000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis2.Add(0);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 5000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis3.Add(0);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 10000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis4.Add(0);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 50000: " + watch.ElapsedTicks);
                    watch.Reset();
                    break;
                case 1:
                    //Runtime for Add Method
                    Console.WriteLine("----List Indexer----");

                    watch.Start();
                    lis1[100] = 20;
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 1000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis2[100] = 20;
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 5000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis3[100] = 20;
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 10000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis4[100] = 20;
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 50000: " + watch.ElapsedTicks);
                    watch.Reset();
                    break;
                case 2:
                    //Runtime for Count Method
                    Console.WriteLine("----List.Count()----");

                    watch.Start();
                    lis1.Count();
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 1000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis2.Count();
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 5000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis3.Count();
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 10000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis4.Count();
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 50000: " + watch.ElapsedTicks);
                    watch.Reset();
                    break;
                case 3:
                    //Runtime for Clear Method
                    Console.WriteLine("----List.Clear()----");

                    watch.Start();
                    lis1.Clear();
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 1000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis2.Clear();
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 5000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis3.Clear();
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 10000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis4.Clear();
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 50000: " + watch.ElapsedTicks);
                    watch.Reset();
                    break;
                case 4:
                    //Runtime for Contains Method
                    Console.WriteLine("----List.Contains()----");

                    watch.Start();
                    lis1.Contains(5);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 1000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis2.Contains(5);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 5000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis3.Contains(5);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 10000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis4.Contains(5);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 50000: " + watch.ElapsedTicks);
                    watch.Reset();
                    break;
                case 5:
                    //Runtime for CopyTo Method
                    Console.WriteLine("----List.CopyTo()----");
                    int[] arr1 = new int[10];


                    watch.Start();
                    lis1.CopyTo(arr1,0);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 1000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis2.CopyTo(arr1, 0);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 5000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis3.CopyTo(arr1, 0);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 10000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis4.CopyTo(arr1, 0);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 50000: " + watch.ElapsedTicks);
                    watch.Reset();
                    break;
                case 6:
                    //Runtime for Insert Method
                    Console.WriteLine("----List.Insert()----");

                    watch.Start();
                    lis1.Insert(0,20);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 1000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis2.Insert(0,20);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 5000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis3.Insert(0,20);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 10000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis4.Insert(0,20);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 50000: " + watch.ElapsedTicks);
                    watch.Reset();
                    break;
                case 7:
                    //Runtime for Remove Method
                    Console.WriteLine("----List.Remove()----");

                    watch.Start();
                    lis1.Remove(10);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 1000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis2.Remove(10);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 5000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis3.Remove(10);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 10000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis4.Remove(10);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 50000: " + watch.ElapsedTicks);
                    watch.Reset();
                    break;
                case 8:
                    //Runtime for RemoveAt Method
                    Console.WriteLine("----List.RemoveAt()----");

                    watch.Start();
                    lis1.RemoveAt(0);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 1000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis2.RemoveAt(0);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 5000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis3.RemoveAt(0);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 10000: " + watch.ElapsedTicks);
                    watch.Reset();

                    watch.Start();
                    lis4.RemoveAt(0);
                    watch.Stop();

                    Console.WriteLine("Time taken for an array length of 50000: " + watch.ElapsedTicks);
                    watch.Reset();
                    break;
            }
            Console.WriteLine();
        }
    }

    
}
