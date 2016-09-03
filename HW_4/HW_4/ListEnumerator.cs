using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW_4
{
    class ListEnumerator<T> : IEnumerator<T>
    {
        int currentPos, collectionLength;
        bool firstRun;
        T[] dataCollection;
        public ListEnumerator(T[] arr, int length)
        {
            firstRun = true;
            dataCollection = arr;
            collectionLength = length-1;
        }
        public T Current
        {
            get { return dataCollection[currentPos]; }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (firstRun)
            {
                currentPos = 0;
                firstRun = false;
                return true;
            }
            if (currentPos < collectionLength)
            {
                currentPos++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
    class ListEnumeratorCompiler<T> : IEnumerator<T>
    {
        int collectionLength,state,currentPos, initialThreadId;
        T current;
        T[] dataCollection;
        public ListEnumeratorCompiler(int st,T[] arr,int length)
        {
            state = st;
            currentPos = state;
            dataCollection = arr;
            collectionLength = length - 1;

            initialThreadId = Thread.CurrentThread.ManagedThreadId;
        }
        public T Current
        {
            get { return current; }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (state >= 0 && state < collectionLength)
            {
                
                state = -1;
                current = dataCollection[currentPos];
                state = currentPos;
                currentPos++;

                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
