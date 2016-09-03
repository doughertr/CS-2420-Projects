using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4
{
    class MergeSort : IsSorter
    {
        /*
        merge sort will execute at O(n*log(n)) because it will have to divide/partition
        the list a total of log(n) amount of times. After dividing the list down, it will 
        take n amount of times to completely combine the sorted sections together into one 
        sorted list because it has to iterate through the list n number of times. Therefore 
        merge sort's worst case scenario will be O(n*log(n))
        */
        public MergeSort()
        {


        }
        public void Sort(int[] arr)
        {
            int start = 0, end = arr.Length - 1, arrayLength = arr.Length;
            Divide(arr, start, end, arrayLength);
        }
        private void Divide(int[] arr, int start, int end, int arrayLength = 20)
        {
            if (end > start)
            {
                int center = (start + end) / 2;
                //left side split
                Divide(arr, start, center, arrayLength);
                //right side split
                Divide(arr, center + 1, end, arrayLength);

                mergeTogether(arr, start, center + 1, end, arrayLength);
            }

        }
        private void mergeTogether(int[] arr, int start,int center, int end, int tempArrayLength)
        {
            int[] tempArray = new int[tempArrayLength]; //20 is the default length if nothing is initially passed
            int numberElements = (end - start + 1);

            int indexArray = start; 
            int indexLeft = start;
            int indexRight = center;

            while (indexLeft <= center-1 && indexRight <= end)
            {
                if (arr[indexLeft] <= arr[indexRight])
                {
                    tempArray[indexArray] = arr[indexLeft];
                    indexArray++;
                    indexLeft++;
                }
                else
                {
                    tempArray[indexArray] = arr[indexRight];
                    indexArray++;
                    indexRight++;
                }

            }
            while(indexLeft <= center-1)
            {
                tempArray[indexArray] = arr[indexLeft];
                indexArray++;
                indexLeft++;
            }
            while (indexRight <= end)
            {
                tempArray[indexArray] = arr[indexRight];
                indexArray++;
                indexRight++;
            }
            //merge tempArray into first array
            for (int arrIndex = 0; arrIndex < numberElements; arrIndex++,end--)
            {
                arr[end] = tempArray[end];
            }
        }
    }
}
