using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4
{
    class SelectionSort : IsSorter
    /*
    the selection sort will execute at O(n^2) in the worst case scenario because it 
    must loop through the entire list to find the lowest index in the unsorted
    portion of the list and then swap it with index i to place it in the sorted 
    portion. This entire process will continue n amount of times (until i reaches the
    last index or, in other words, when all of the minIndexes of the unsorted portion
    of the array have been placed into the sorted portion) until the list is fully sorted.  
    Since selection sort must loop through the entire list n number times and then also
    loop through the unsorted portion of the list n number times, it is O(n^2).
    */
    {
        public SelectionSort()
        {

        }
        public void Sort(int[] arr)
        {
            int minIndex;
            for (int i = 0; i < arr.Length -1; i++)
            {
                minIndex = i;
                for (int k = i+1; k < arr.Length; k++)
                {
                    if (arr[k] < arr[minIndex])
                    {
                        minIndex = k;
                    }
                }
                if(minIndex != i)//swaping
                {
                    Swap(arr, i, minIndex);
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
