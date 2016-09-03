using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4
{
    class QuickSort: IsSorter
    {
        /*
        Quick sort on average will execute at O(n*log(n)) because it will 
        partition the array into 2 parts log(n) amount of times. It then must
        iterate through the array n number of times to find the sorted position
        of the pivot. However, if Quick Sort chooses the wost pivot each time then
        it will partition the array n number amount of times making the worst
        case scenario O(n^2)
        */
        public QuickSort()
        {

        }
        public void Sort(int[] arr)
        {
            int start = 0, end = arr.Length - 1;
            Divide(arr, start, end);
        }

        private void Divide(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int sortedPos = sortPivot(arr, start, end);
                Divide(arr, start, sortedPos - 1);
                Divide(arr, sortedPos + 1, end);
            }
        }

        private int sortPivot(int[] arr, int start, int end)
        {
            int pivot = end;
            int wall = start;

            for(int i = start; i < end; i++)
            {
                if (arr[i] < arr[pivot])
                {
                    Swap(arr,wall, i);
                    wall++;
                }
            }
            Debug.Assert(pivot == end, "the pivot invariant was changed");
            Swap(arr, pivot, wall);
            pivot = wall;
            return wall;
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
