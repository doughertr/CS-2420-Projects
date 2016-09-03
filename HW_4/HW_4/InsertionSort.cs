using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4
{
    class InsertionSort : IsSorter
    {
        /*
        the insertion sort function will execute at O(n^2) in the worst case scenario
        because it will take a value out of the unsorted sectionn and loop through the 
        sorted portion and compare the value to every sorted value. Once the correct 
        position has been found the chosen value will be inserted into the sorted portion.
        This process will repeat n number of times. Since insertion sort must loop through
        the list n number of times and then loop through the sorted portion of the list
        n number of times, it is a O(n^2).
        */
        public InsertionSort()
        {

        }
        public void Sort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int pos = i;
                while(pos > 0 && arr[pos] <= arr[pos - 1])
                {
                    Swap(arr, pos, pos - 1);
                    pos--;
                }
            }
        }
        private void Swap(int[] arr, int pos1, int pos2)
        {
            Debug.Assert(pos1 < arr.Length && pos1 >= 0 && pos2 < arr.Length && pos2 >= 0, "positions are out of bounds for swap");
            int tempNum = arr[pos1];
            arr[pos1] = arr[pos2];
            arr[pos2] = tempNum;
        }
    }
}
