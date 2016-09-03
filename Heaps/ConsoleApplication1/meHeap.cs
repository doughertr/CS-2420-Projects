using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class meHeap<T> where T : IComparable
    {
        T[] underlyingArray;
        public meHeap(T[] arr)
        {
            underlyingArray = arr;
        }
        public void Add(T val)
        {
            T[] tempArray = new T[underlyingArray.Length + 1];
            underlyingArray.CopyTo(tempArray,0);
            underlyingArray = tempArray;
            swim(val);

        }
        private void swim(T val)
        {
            //keep looking at parent and swapping if the parent is less than the added value
            T runnerVal = val;
            int runnerIndex = underlyingArray.Length - 1;
            int childIndex = runnerIndex/2;
            while (true)
            {

                if (runnerVal.CompareTo(underlyingArray[childIndex]) >= 0)
                {
                    Swap(runnerIndex, childIndex);
                    runnerIndex = childIndex;
                    childIndex /= 2;
                }
                else
                {
                    break;
                }
            }
        }
        public void sink(T val, int startIndex, int endIndex)
        {
            T runnerVal = val;
            int runnerIndex = startIndex;
            int childIndex = runnerIndex * 2;
            while(childIndex < endIndex)
            {
                
                if (runnerVal.CompareTo(underlyingArray[childIndex]) <= 0)
                {
                    Swap(runnerIndex, childIndex);
                    runnerIndex = childIndex;
                    childIndex *= 2;
                }            
                else if (runnerVal.CompareTo(underlyingArray[childIndex + 1]) <= 0)
                {
                    Swap(runnerIndex, ++childIndex);
                    runnerIndex = childIndex;
                    childIndex *= 2;
                }
                else
                {
                    break;
                }
            }
        }
        public T PopTop()
        {
            return underlyingArray[0];
        }
        private void Swap(int index1, int index2 )
        {
            T tempVal = underlyingArray[index1];
            underlyingArray[index1] = underlyingArray[index2];
            underlyingArray[index2] = tempVal;
        }
        public void HeapSort()
        {
            //swap the front with the end and then sink it
            //use a wall to seperate between unsorted heap and sorted portion of the heap
            int wall = underlyingArray.Length - 1;
            while(wall > 0)
            {
                Swap(wall, 0);
                sink(underlyingArray[0], wall);

            }
        }
    }
}
