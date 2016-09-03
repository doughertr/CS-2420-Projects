using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4
{
    class BubbleSort : IsSorter
    {
        public BubbleSort()
        {

        }
        public void Sort(int[] arr)
        /*
        the bubble sort will execute at O(n^2) because in the worst case scenario 
        the function must loop through the entire list of n length to make sure that
        every value at position i is less than the value at position i +1. Then the 
        function must then repeat this entire process n number of times until the list 
        is fully sorted. Since bubble sort must loop through the list n times and then 
        check to make sure every value is greater than its following value n times as 
        well, it is considered O(n^2)
        */
        {
            bool continueLoop = true;
            while (continueLoop)
            {
                continueLoop = false;
                for(int i = 0; i < arr.Length - 1;i++)
                {
                    if (arr[i + 1] < arr[i])
                    {
                        int temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                        continueLoop = true;
                    }
                }
            }
        }
    }
}
