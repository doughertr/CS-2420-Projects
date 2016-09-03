using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4
{
    class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Value { get; set; }
    }
    class LinkedList : IEnumerable<int>
    {
        Node<int> head;
        public LinkedList()
        {
            head = new Node<int> { Value = 5 };

        }
        class MyEnumerator : IEnumerator<int>
        {
            Node<int> runner;
            bool started = false;
            public MyEnumerator(LinkedList lis)
            {
                runner = lis.head;
            }
            public bool MoveNext()
            {
                if (started && runner != null)
                {
                    runner = runner.Next;
                }
                started = true;
                return runner != null;
            }
            public int Current
            {
                get{ return runner.Value;}
            }

            object IEnumerator.Current
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
            public void Dispose()
            {
                throw new NotImplementedException();
            }
            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
        public IEnumerator<int> GetEnumerator()
        {
            return new MyEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
