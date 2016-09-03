using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BitFunctions.ConvertDecimalToBinary(5));
            Console.WriteLine(BitFunctions.NumOfOnBits(31));
            int[] testArr1 = { 1, 2, 3, 7, 9, 11, 17 };
            
            Console.WriteLine(BinarySearch.Find(3, testArr1, 0, testArr1.Length));
            Console.ReadLine();
        }
    }

    class InsertionSort
    { 
        public static void Sort(int[] unsortedArray)
        {
            for (int i = 1; i < unsortedArray.Length; i++)
            {
                int pos = i;
                while(pos > 0 && unsortedArray[pos] <= unsortedArray[pos-1]) //looping through sorted section and determining where the value at index of pos belongs
                {
                    Swap(pos, pos-1, unsortedArray);
                    pos--;
                }
            }
        }
        public static void Swap(int index1, int index2, int[] array)
        {
            int tempVal = array[index1];
            array[index1] = array[index2];
            array[index2] = tempVal;
        }
    }
    class SelectionSort
    {
        /*
        variable i represents the invariant for the wall. anything before or equal to i is sorted
        */
        public static void Sort(int[] unsortedArray)
        {
            for(int i = 0; i < unsortedArray.Length-1; i++)
            {
                int minimumIndex = i;
                for (int k = i + 1; k < unsortedArray.Length; k++)
                {
                    if (unsortedArray[k] < unsortedArray[minimumIndex])
                        minimumIndex = k; 

                }
                Swap(minimumIndex, i,unsortedArray);

            }
        }
        public static void Swap(int index1, int index2, int[] array)
        {
            int tempVal = array[index1];
            array[index1] = array[index2];
            array[index2] = tempVal;
        }
    }
    class BubbleSort
    {
        public static void Sort(int[] unsortedArray)
        {
            bool continueLoop = true;
            while (continueLoop)
            {
                continueLoop = false;
                for (int i = 0; i < unsortedArray.Length - 1; i++)
                {
                    if (unsortedArray[i+1] < unsortedArray[i])
                    {
                        Swap(i, i + 1, unsortedArray);
                        continueLoop = true;
                    }
                }
            }
        }
        public static void Swap(int index1, int index2, int[] array)
        {
            int tempVal = array[index1];
            array[index1] = array[index2];
            array[index2] = tempVal;
        }
    }
    class BitFunctions
    {
        public static int NumOfOnBits(int num)
        {
            int mask, isOn;
            int counter = 0;
            for (int i = 0; i < 32; i++)
            {
                mask = 1 << i;
                //Console.WriteLine(mask);
                isOn = mask & num;

                if (isOn != 0)
                {
                    counter++;
                }
            }
            return counter;
        }
        public static int NumOfOffBits(int num)
        {
            int mask, isOff;
            int counter = 0;
            for (int i = 0; i < 32; i++)
            {
                mask = 1 << i;
                isOff = num & mask;

                if (isOff == 0)
                {
                    counter++;
                }
            }
            return counter;
        }
        public static int ConvertDecimalToBinary(int num)
        {
            int mask, isOn, result = 0;
            for(int i = 0; i < 32; i++)
            {
                mask = 1 << i;
                isOn = num & mask;
                if (isOn != 0)
                {
                    result += (int)Math.Pow(10, i);
                }
            }
            return result;
        }
    }
    class BinarySearch
    {
        public static int Find(int value, int[] arr, int start, int end)
        {
            int center = (start + end) / 2;

            if (end - start <= 1 && value != arr[center])
                return -1;

            if (value < arr[center])
                return Find(value, arr, start, center);
            else if (value > arr[center])
                return Find(value, arr, center + 1, end);
            else
                return center;
        }
    }

}
