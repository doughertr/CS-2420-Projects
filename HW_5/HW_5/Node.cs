using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5
{
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> leftChild { get; set; }
        public Node<T> rightChild { get; set; }

        public IEnumerator<T> TraversePre()
        {
            yield return Value;
            if (leftChild != null)
            {
                IEnumerator<T> leftChildEnumerator = leftChild.TraversePre();
                while (leftChildEnumerator.MoveNext() == true)
                    yield return leftChildEnumerator.Current;
            }
            if (rightChild != null)
            {
                IEnumerator<T> rightChildEnumerator = rightChild.TraversePre();
                while (rightChildEnumerator.MoveNext() == true)
                    yield return rightChildEnumerator.Current;
            }
        }
        public IEnumerator<T> TraverseIn()
        {
            
            if (leftChild != null)
            {
                IEnumerator<T> leftChildEnumerator = leftChild.TraverseIn();
                while (leftChildEnumerator.MoveNext() == true)
                    yield return leftChildEnumerator.Current;
            }
            yield return Value;
            if (rightChild != null)
            {
                IEnumerator<T> rightChildEnumerator = rightChild.TraverseIn();
                while (rightChildEnumerator.MoveNext() == true)
                    yield return rightChildEnumerator.Current;
            }
        }

        public IEnumerator<T> TraversePost()
        {

            if (leftChild != null)
            {
                IEnumerator<T> leftChildEnumerator = leftChild.TraversePost();
                while (leftChildEnumerator.MoveNext() == true)
                    yield return leftChildEnumerator.Current;
            }
            if (rightChild != null)
            {
                IEnumerator<T> rightChildEnumerator = rightChild.TraversePost();
                while (rightChildEnumerator.MoveNext() == true)
                    yield return rightChildEnumerator.Current;
            }
            yield return Value;
        }
    }
}
