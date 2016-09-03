using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7
{
    class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public LinkedList<KeyValuePair<TKey, TValue>>[] underlyingArray;
        int counter;
        public double loadCapacity;
        double maxCapacity;
        List<TKey> allKeys;
        List<TValue> allValues;
        IEnumerator<int> primes;

        public MyDictionary(double maxCapacity = 75)
        {
            this.maxCapacity = maxCapacity;
            PrimeNumbers primeNumberClass = new PrimeNumbers();
            primes = primeNumberClass.GetEnumerator();
            underlyingArray = new LinkedList<KeyValuePair<TKey, TValue>>[7];
            counter = 0;
            loadCapacity = 0;
            allKeys = new List<TKey>();
            allValues = new List<TValue>();
        }
  
        private void AddKeyAndValue(TKey key, TValue value)
        {
            allKeys.Add(key);
            allValues.Add(value);
        }

        private void RemoveKeyAndValue(TKey key, TValue value)
        {
            allKeys.Remove(key);
            allValues.Remove(value);
        }

        private void CheckCapacity()
        {
            double percentage = 100;
            loadCapacity = ((double)counter / (double)underlyingArray.Length) * percentage;
            if(loadCapacity >= maxCapacity)
            {
                ExpandArray();
            }
        }

        private void ExpandArray()
        {
            //Console.WriteLine("Expanding Array...");
            int count = underlyingArray.Length / 2;
            while(count >= 0) //generates a prime number that is length/2 prime numbers away 
            {
                primes.MoveNext();
                count--;
            }
            LinkedList<KeyValuePair<TKey, TValue>>[] tempArray = underlyingArray;
            underlyingArray = new LinkedList<KeyValuePair<TKey, TValue>>[primes.Current];
            counter = 0;
            loadCapacity = 0;
            allKeys = new List<TKey>();
            allValues = new List<TValue>();

            for (int bucket = 0; bucket < tempArray.Length; bucket++)
            {
                if(tempArray[bucket] != null)
                {
                    foreach (KeyValuePair<TKey, TValue> pair in tempArray[bucket])
                    {
                        Add(pair);
                    }
                } 
            }
        }

        private bool HelperFunc(
            int hashCode, 
            Func<KeyValuePair<TKey, TValue>, bool> predicate, 
            Action<KeyValuePair<TKey, TValue>, LinkedList<KeyValuePair<TKey, TValue>>> doSomething = null)
        {
            int bucket = hashCode % underlyingArray.Length;
            if (underlyingArray[bucket] == null)
                underlyingArray[bucket] = new LinkedList<KeyValuePair<TKey, TValue>>();
            LinkedList<KeyValuePair<TKey, TValue>> bucketList = underlyingArray[bucket];
            foreach (KeyValuePair<TKey, TValue> pair in bucketList)
            {
                if (predicate(pair))
                {
                    if(doSomething != null)
                        doSomething(pair,bucketList);
                    return true;
                }
            }
            return false;
        }

        public TValue this[TKey key]
        {
            get
            {
                int hash = Math.Abs(key.GetHashCode());
                int bucket = hash % underlyingArray.Length;
                if (underlyingArray[bucket] == null)
                    underlyingArray[bucket] = new LinkedList<KeyValuePair<TKey, TValue>>();
                LinkedList<KeyValuePair<TKey, TValue>> bucketList = underlyingArray[bucket];
                foreach (KeyValuePair<TKey, TValue> pair in bucketList)
                {
                    if (pair.Key.Equals(key))
                        return pair.Value;
                }
                throw new Exception();
            }

            set
            {
                if (allKeys.Contains(key))
                    Remove(key);
                Add(key, value);
            }
        }

        public int Count
        {
            get
            {
                return counter;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                return allKeys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                return allValues;
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            if (!allKeys.Contains(item.Key))
            {
                CheckCapacity();
                int hash = Math.Abs(item.Key.GetHashCode());
                int bucket = hash % underlyingArray.Length;
                if (underlyingArray[bucket] == null)
                    underlyingArray[bucket] = new LinkedList<KeyValuePair<TKey, TValue>>();
                LinkedList<KeyValuePair<TKey, TValue>> bucketList = underlyingArray[bucket];
                bucketList.AddLast(item);
                AddKeyAndValue(item.Key, item.Value);

                counter++;
            }
            else
            {
                throw new Exception();
            }     
        }

        public void Add(TKey key, TValue value)
        {
            if (!allKeys.Contains(key))
            {
                CheckCapacity();
                KeyValuePair<TKey, TValue> newPair = new KeyValuePair<TKey, TValue>(key, value);
                int hash = Math.Abs(key.GetHashCode());
                int bucket = hash % underlyingArray.Length;
                if (underlyingArray[bucket] == null)
                    underlyingArray[bucket] = new LinkedList<KeyValuePair<TKey, TValue>>();
                LinkedList<KeyValuePair<TKey, TValue>> bucketList = underlyingArray[bucket];
                bucketList.AddLast(newPair);
                AddKeyAndValue(newPair.Key, newPair.Value);
                counter++;
            }
            else
            {
                throw new Exception();
            }
        }

        public void Clear()
        {
            underlyingArray = new LinkedList<KeyValuePair<TKey, TValue>>[7];
            PrimeNumbers primeNumberClass = new PrimeNumbers();
            primes = primeNumberClass.GetEnumerator();
            counter = 0;
            loadCapacity = 0;
            allKeys = new List<TKey>();
            allValues = new List<TValue>();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            int hash = Math.Abs(item.Key.GetHashCode());
            return HelperFunc(hash , x => x.Equals(item));
            /*int bucket = hash % underlyingArray.Length;
            if (underlyingArray[bucket] == null)
                underlyingArray[bucket] = new LinkedList<KeyValuePair<TKey, TValue>>();
            LinkedList<KeyValuePair<TKey, TValue>> bucketList = underlyingArray[bucket];
            foreach (KeyValuePair<TKey, TValue> pair in bucketList)
            {
                if (pair.Equals(item))
                    return true;
            }
            return false;*/
        }

        public bool ContainsKey(TKey key)
        {
            int hash = Math.Abs(key.GetHashCode());
            return HelperFunc(hash, x => x.Key.Equals(key));
            /*int bucket = hash % underlyingArray.Length;
            if (underlyingArray[bucket] == null)
                underlyingArray[bucket] = new LinkedList<KeyValuePair<TKey, TValue>>();
            LinkedList<KeyValuePair<TKey, TValue>> bucketList = underlyingArray[bucket];
            foreach (KeyValuePair<TKey, TValue> pair in bucketList)
            {
                if (pair.Key.Equals(key))
                    return true;
            }
            return false;*/
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            for(int bucket = 0; bucket < underlyingArray.Length; bucket++)
            {
                if (underlyingArray[bucket] != null)
                {
                    foreach (KeyValuePair<TKey, TValue> pair in underlyingArray[bucket])
                    {
                        array[arrayIndex++] = pair;
                    }
                }   
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for(int bucket = 0; bucket <underlyingArray.Length; bucket++)
            {
                if (underlyingArray[bucket] != null)
                {
                    foreach (KeyValuePair<TKey, TValue> pair in underlyingArray[bucket])
                    {
                        yield return pair;
                    }
                }
            }
        }

        private void RemoveHelper(KeyValuePair<TKey, TValue> pair, LinkedList<KeyValuePair<TKey, TValue>> list)
        {
            list.Remove(pair);
            RemoveKeyAndValue(pair.Key, pair.Value);
            counter--;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            int hash = Math.Abs(item.Key.GetHashCode());
            return HelperFunc(hash, x => x.Equals(item), RemoveHelper);
        }

        public bool Remove(TKey key)
        {
            int hash = Math.Abs(key.GetHashCode());
            return HelperFunc(hash, x => x.Key.Equals(key), RemoveHelper);
        }

        public bool TryGetValue(TKey key, out TValue value) //value is set to found value
        {
            value = default(TValue);
            int hash = key.GetHashCode();
            int bucket = hash % underlyingArray.Length;
            if (underlyingArray[bucket] == null)
                underlyingArray[bucket] = new LinkedList<KeyValuePair<TKey, TValue>>();
            LinkedList<KeyValuePair<TKey, TValue>> bucketList = underlyingArray[bucket];
            foreach (KeyValuePair<TKey, TValue> pair in bucketList)
            {
                if (pair.Key.Equals(key))
                {
                    value = pair.Value;
                    return true;
                }       
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
