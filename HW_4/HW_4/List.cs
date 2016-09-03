using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace HW_4
{
    class List<T> : IList<T>, IEnumerable<T>
    {
        T[] underlyingArray;
        int counter, currentSize;
        bool isReadOnly;
        public List(int initSize = 5, bool readOnly = false) //constructer 
        {
            underlyingArray = new T[initSize];
            currentSize = initSize;
            isReadOnly = readOnly;

            counter = 0;
        }
        public T this[int index]
            /*
            this function will run at O(1) since all it is doing is returning the data at the given index.
            Therefore this will always execute at a constant time
            */
        {
            get
            {
                if(index < counter)
                {
                    return underlyingArray[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
                    
            }
            set
            {
                if (index < counter)
                {
                    underlyingArray[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
                    
        }

        private void GrowArray()
        {
            T[] tempunderlyingArray = new T[currentSize * 2];
            for (int i = 0; i < currentSize; i++)
            {
                CopyTo(tempunderlyingArray, i);
            }
            currentSize *= 2;
            underlyingArray = new T[currentSize];
            underlyingArray = tempunderlyingArray;


        }
        public int CurrentSize
        {
            get { return currentSize; }
        }
        public int Count
        /*
        this function will run at O(1) since all it is doing is returning the counter value's 
        data which is stored as a single integer. Therefore this will always execute at a constant 
        time regardless of the list's size 
        */
        {
            get { return counter; }
        }

        public T[] UnderlyingArray
        {
            get { return underlyingArray; }
        }

        public bool IsReadOnly
        {
            get { return isReadOnly; }
        }
        public void Add(T item)
        /*
        this function will run at O(1) as long as the counter is less than/not equal to the 
        array's current size. When the counter is equal to the current size, then the function
        will have to grow the array. In this case the function will run at O(n) because it 
        must loop through the entire array so that it can copy each value over to the 
        newer/bigger array. 
        */
        {
            if (!isReadOnly)
            {
                if (counter == currentSize)
                    GrowArray();
                underlyingArray[counter++] = item;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public void Clear()
        /*
        this function will run at O(1) since it is only reassigning the array to
        a new empty array of only 5 positions. Therefore this will always execute at a constant 
        time regardless of the list's size 
        */
        {

            if (!isReadOnly)
            {
                underlyingArray = new T[5];
                counter = 0;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public bool Contains(T item)
        /*
        this function will run at O(n) because (in the worst case senario) it will loop through the 
        entire list until it finds the desired value it is looking for. Therefore the order in which 
        this function runs at is directly related to the size of the list (linear)
        */
        {
            for (int i = 0; i < counter; i++)
            {
                if (underlyingArray[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
        
        public void CopyTo(T[] array, int arrayIndex)
        /*
        This function will run at O(1) because it is simply copying a passed value from the 
        underlyingarray to a passed array. Therefore this function will always execute at a
        constant time regardless of both arrays' sizes
        */
        {
            if (!isReadOnly)
            {
                Debug.Assert(arrayIndex >= 0 && arrayIndex < currentSize && arrayIndex < array.Length);
                array[arrayIndex] = underlyingArray[arrayIndex];
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < counter; i++)
                yield return underlyingArray[i];
        }
        public IEnumerator GetEnumeratorNoYield()
        {
            return new ListEnumerator<T>(underlyingArray,counter);
        }
        public IEnumerator GetEnumeratorCompiler()
        {
            return new ListEnumeratorCompiler<T>(0,underlyingArray,counter);
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < counter; i++)
            {
                if (underlyingArray[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        /*
        this function will execute at O(n) as long as the counter is less than/not equal to the
        list's current size because (in the worst case senario) it must loop through the entire 
        list to shift all values to the index to the right. When the counter is equal to the 
        lists current size, then this function will execute at O(n^2) because it must also grow 
        the array. In this case the function must loop through the entire array once more so that 
        it can copy each value over to the newer/bigger array. 
        */
        {
            if (!isReadOnly)
            {
                if (counter == 0)
                {
                    Add(item);
                }
                else if (index >= 0 && index < counter) {
                    if (counter == currentSize)
                        GrowArray();

                    for (int i = counter; i > index; i--)
                    {
                        underlyingArray[i] = underlyingArray[i-1];
                    }
                    underlyingArray[index] = item;
                    counter++;
                }
                else {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }


        public bool Remove(T item)
        /*
        this function will execute at O(n^2) because it must first loop through the entire 
        list (in the worst case senario) in order to find the value that needs to be removed.
        Next the function must loop through the list once more so that all indexes in front of 
        the removed item will be shifted down one index. However, this function will execute at
        only O(n) when the item is not found in the list because it only needs to iterate 
        through the list once. 
        */
        {
            if (!isReadOnly)
            {
                for (int i = 0; i < counter; i++)
                {
                    if (underlyingArray[i].Equals(item))
                    {
                        RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }
            else
            {
                throw new InvalidOperationException();
            }

        }

        public void RemoveAt(int index)
        /*
        this function will execute at O(n) because it must iterate through the entire list
        (in worst case senario) to shift every value after the removed index an index to 
        the left. Therefore the order in which this function runs at is directly related to 
        the size of the list (linear)
        */
        {
            if (!isReadOnly)
            {
                if (index >= 0 && index < counter)
                {
                    for (int i = index; i < counter; i++)
                    {
                        try
                        {
                            underlyingArray[i] = underlyingArray[i + 1];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            underlyingArray[i] = default(T);
                        }

                    }
                    counter--;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                throw new InvalidOperationException();
            }

        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new ListEnumerator<T>(underlyingArray,counter);
        }
    }
}
