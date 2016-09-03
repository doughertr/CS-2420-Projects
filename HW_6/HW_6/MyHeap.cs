using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6
{
    class MyHeap<T> : IEnumerable<T> where T : IComparable<T>
    {
        public List<T> underlyingList { get; private set; }
        public int Count { get; private set; }
        private IComparer<T> comparer;

        public MyHeap(IComparer<T> comparer = null)
        {
            Count = 0;
            this.comparer = comparer;
            underlyingList = new List<T>();
            underlyingList.Add(default(T));
        }

        private void Swim(int startIndex, int endIndex)
        {
            int runnerIndex = startIndex;
            int parentIndex = runnerIndex / 2;

            if (comparer != null)
            {
                while (parentIndex >= endIndex && comparer.Compare(underlyingList[runnerIndex], underlyingList[parentIndex]) > 0)
                {
                    Swap(runnerIndex, parentIndex);
                    runnerIndex = parentIndex;
                    parentIndex /= 2;
                }
            }
            else
            {
                while (parentIndex >= endIndex && underlyingList[runnerIndex].CompareTo(underlyingList[parentIndex]) > 0 )
                {
                    Swap(runnerIndex, parentIndex);
                    runnerIndex = parentIndex;
                    parentIndex /= 2;
                }
            }

        }
        private void Sink(int startIndex, int endIndex)
        {
            int runnerIndex = startIndex;
            int childIndex = runnerIndex * 2;
            if (comparer != null)
            {
                while (childIndex <= endIndex)
                {
                    if (childIndex + 1 <= endIndex && comparer.Compare(underlyingList[childIndex + 1], underlyingList[childIndex]) > 0)
                    {
                        childIndex++;
                    }

                    if (comparer.Compare(underlyingList[childIndex], underlyingList[runnerIndex]) > 0)
                    {
                        Swap(runnerIndex, childIndex);
                    }
                    else
                    {
                        break;
                    }
                    runnerIndex = childIndex;
                    childIndex = 2 * runnerIndex;
                }
            }
            else
            {
                while (childIndex <= endIndex)
                {
                    if (childIndex + 1 <= endIndex && underlyingList[childIndex + 1].CompareTo(underlyingList[childIndex]) > 0)
                    {
                        childIndex++;
                    }

                    if (underlyingList[childIndex].CompareTo(underlyingList[runnerIndex]) > 0)
                    {
                        Swap(runnerIndex, childIndex);
                    }
                    else
                    {
                        break;
                    }
                    runnerIndex = childIndex;
                    childIndex = 2 * runnerIndex;
                }
            }

        }
        private void Swap(int index1, int index2)
        {
            T tempVal = underlyingList[index1];
            underlyingList[index1] = underlyingList[index2];
            underlyingList[index2] = tempVal;
        }

        public T this[int index]
        {
            get { return underlyingList[index]; }
        }
        public void Add(T val)
        {
            underlyingList.Add(val);
            if(Count > 0)
                Swim(underlyingList.Count - 1, 1);
            Count++;
        }
        public bool Remove(T val)
        {
            int valIndex = underlyingList.IndexOf(val);
            if (valIndex == -1)
                return false;

            underlyingList.RemoveAt(valIndex);

            underlyingList.Insert(valIndex, underlyingList[underlyingList.Count - 1]);
            underlyingList.RemoveAt(underlyingList.Count - 1);
            //BuildHeap();
            if (comparer != null)
            {
                if (valIndex / 2 != 0 && comparer.Compare(underlyingList[valIndex], underlyingList[valIndex / 2]) > 0)
                {
                    Swim(valIndex, 1);
                }
                else
                {
                    Sink(valIndex, underlyingList.Count - 1);
                }
            }
            else
            {
                if (valIndex / 2 != 0 && underlyingList[valIndex].CompareTo(underlyingList[valIndex / 2]) > 0)
                {
                    Swim(valIndex, 1);
                }
                else
                {
                    Sink(valIndex, underlyingList.Count - 1);
                }
            }
            Count--;
            return true;
        }
        public T PopTop()
        {
            T topValue = underlyingList[1];
            underlyingList.RemoveAt(1);

            underlyingList.Insert(1, underlyingList[underlyingList.Count - 1]);
            underlyingList.RemoveAt(underlyingList.Count - 1);

            Sink(1, underlyingList.Count - 1);
            Count--;

            return topValue;
        }
        public void Sort()
        {
            int wall = underlyingList.Count - 1;
            while (wall > 1)
            {
                Swap(1, wall);
                Sink(1, wall - 1);
                wall--;
            }
        }
        public void BuildHeap()
        {
            List<T> tempList = new List<T>();
            foreach (T value in underlyingList)
            {
                tempList.Add(value);
            }
            Clear();
            foreach (T value in tempList)
            {
                Add(value);
            }
        }
        public bool Contains(T value)
        {
            return underlyingList.Contains(value);
        }
        public void Clear()
        {
            underlyingList.Clear();
        }
        public override string ToString()
        {
            IEnumerator<T> traverse = GetEnumerator();
            string returnedString = "";
            while (traverse.MoveNext())
            {
                returnedString += traverse.Current.ToString() + " ";
            }
            return returnedString;
        }
        public IEnumerator<T> GetEnumerator()
        {
            yield return underlyingList[1];
            for (int parentIndex = 1; parentIndex <= (underlyingList.Count / 2) - 1; parentIndex++)
            {
                yield return underlyingList[parentIndex * 2];
                if (((parentIndex * 2) + 1) < underlyingList.Count)
                    yield return underlyingList[(parentIndex * 2) + 1];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
