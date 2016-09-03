using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAdd();
            TestIndexer();
            TestRemove();
            TestExpandArray();
            TestContains();
            TestTryGetValue();
            TestClear();
            TestEnumerator();
            Console.ReadLine();
        }

        static void TestAdd()
        {
            MyDictionary<int, string> testDict = new MyDictionary<int, string>();
            Console.WriteLine("Testing Adding Function...");
            Console.WriteLine();
            testDict.Add(1, "A"); Console.WriteLine("Adding: 1-A"); Debug.Assert(testDict[1].Equals("A"));
            testDict.Add(43, "B"); Console.WriteLine("Adding: 43-B"); Debug.Assert(testDict[43].Equals("B"));
            testDict.Add(7, "C"); Console.WriteLine("Adding: 7-C"); Debug.Assert(testDict[7].Equals("C"));
            testDict.Add(9, "C"); Console.WriteLine("Adding: 9-C"); Debug.Assert(testDict[9].Equals("C"));
            testDict.Add(50, "K"); Console.WriteLine("Adding: 50-K"); Debug.Assert(testDict[50].Equals("K"));
            testDict.Add(10, "P"); Console.WriteLine("Adding: 10-P"); Debug.Assert(testDict[10].Equals("P"));
            testDict.Add(new KeyValuePair<int, string>(80, "C")); Console.WriteLine("Adding Key Value Pair: 80-C"); Debug.Assert(testDict[80].Equals("C"));
            testDict.Add(new KeyValuePair<int, string>(60, "D")); Console.WriteLine("Adding Key Value Pair: 60-D"); Debug.Assert(testDict[60].Equals("D"));
            testDict.Add(new KeyValuePair<int, string>(2, "L")); Console.WriteLine("Adding Key Value Pair: 2-L"); Debug.Assert(testDict[2].Equals("L"));
            testDict.Add(new KeyValuePair<int, string>(3, "M")); Console.WriteLine("Adding Key Value Pair: 3-M"); Debug.Assert(testDict[3].Equals("M"));
            Console.WriteLine("All Keys: " + string.Join(",", testDict.Keys.ToArray()));
            Console.WriteLine("All Values: " + string.Join(",", testDict.Values.ToArray()));
            Console.WriteLine("Adding Test Suceeded");
            Console.WriteLine();
        }

        static void TestIndexer()
        {
            MyDictionary<string, double> testDict = new MyDictionary<string, double>();
            Console.WriteLine("Testing Indexer Function...");
            Console.WriteLine();
            testDict["A"] = 2.5; Console.WriteLine("Setting index 'A' to 2.5"); Debug.Assert(testDict["A"].Equals(2.5));
            testDict["B"] = 6.8; Console.WriteLine("Setting index 'B' to 6.8"); Debug.Assert(testDict["B"].Equals(6.8));
            testDict["C"] = 7.9; Console.WriteLine("Setting index 'C' to 7.9"); Debug.Assert(testDict["C"].Equals(7.9));
            testDict["D"] = 8.1; Console.WriteLine("Setting index 'D' to 8.1"); Debug.Assert(testDict["D"].Equals(8.1));
            testDict["E"] = 9.9; Console.WriteLine("Setting index 'E' to 9.9"); Debug.Assert(testDict["E"].Equals(9.9));
            testDict["F"] = 8.1; Console.WriteLine("Setting index 'F' to 8.1"); Debug.Assert(testDict["F"].Equals(8.1));
            testDict["G"] = 1.3; Console.WriteLine("Setting index 'G' to 1.3"); Debug.Assert(testDict["G"].Equals(1.3));
            testDict["H"] = 3.1; Console.WriteLine("Setting index 'H' to 3.1"); Debug.Assert(testDict["H"].Equals(3.1));
            testDict["I"] = 4.2; Console.WriteLine("Setting index 'I' to 4.2"); Debug.Assert(testDict["I"].Equals(4.2));
            Console.WriteLine("All Keys: " + string.Join(",", testDict.Keys.ToArray()));
            Console.WriteLine("All Values: " + string.Join(",", testDict.Values.ToArray()));
            Console.WriteLine("Indexer Test Suceeded");
            Console.WriteLine();
        }

        static void TestRemove()
        {
            MyDictionary<int, string> testDict = new MyDictionary<int, string>();
            Console.WriteLine("Testing Remove Function...");
            Console.WriteLine();
            testDict.Add(1, "A"); Console.WriteLine("Adding: 1-A");
            testDict.Add(43, "B"); Console.WriteLine("Adding: 43-B");
            testDict.Add(7, "C"); Console.WriteLine("Adding: 7-C");
            testDict.Add(9, "L"); Console.WriteLine("Adding: 9-C");
            testDict.Add(50, "K"); Console.WriteLine("Adding: 50-K");
            testDict.Add(10, "P"); Console.WriteLine("Adding: 10-P");
            testDict.Add(8, "L"); Console.WriteLine("Adding: 8-L");
            testDict.Add(2, "K"); Console.WriteLine("Adding: 2-K");
            testDict.Add(90, "R"); Console.WriteLine("Adding: 90-R");
            Debug.Assert(testDict.Remove(1)); Console.WriteLine("Removing: 1-A");
            Debug.Assert(testDict.Remove(50)); Console.WriteLine("Removing: 50-K");
            Debug.Assert(testDict.Remove(new KeyValuePair<int, string>(90,"R"))); Console.WriteLine("Removing: 90-R");
            Debug.Assert(!testDict.ContainsKey(1) && !testDict.ContainsKey(50) && !testDict.ContainsKey(90)); Debug.Assert(testDict.Count == 6);
            Console.WriteLine("All Keys: " + string.Join(",", testDict.Keys.ToArray()));
            Console.WriteLine("All Values: " + string.Join(",", testDict.Values.ToArray()));
            Console.WriteLine("Remove Test Suceeded");
            Console.WriteLine();
        }

        static void TestExpandArray()
        {
            MyDictionary<int, string> testDict = new MyDictionary<int, string>();
            Console.WriteLine("Testing ExpandArray Function...");
            Console.WriteLine();
            testDict.Add(1, "A"); Console.WriteLine("Adding: 1-A");
            Console.WriteLine("Dictionary's underlying array length: " + testDict.underlyingArray.Length);
            Console.WriteLine("Dictionary's load capacity: " + testDict.loadCapacity);
            testDict.Add(43, "B"); Console.WriteLine("Adding: 43-B");
            Console.WriteLine("Dictionary's underlying array length: " + testDict.underlyingArray.Length);
            Console.WriteLine("Dictionary's load capacity: " + testDict.loadCapacity);
            testDict.Add(7, "C"); Console.WriteLine("Adding: 7-C");
            Console.WriteLine("Dictionary's underlying array length: " + testDict.underlyingArray.Length);
            Console.WriteLine("Dictionary's load capacity: " + testDict.loadCapacity);
            testDict.Add(9, "L"); Console.WriteLine("Adding: 9-C");
            Console.WriteLine("Dictionary's underlying array length: " + testDict.underlyingArray.Length);
            Console.WriteLine("Dictionary's load capacity: " + testDict.loadCapacity);
            testDict.Add(50, "K"); Console.WriteLine("Adding: 50-K");
            Console.WriteLine("Dictionary's underlying array length: " + testDict.underlyingArray.Length);
            Console.WriteLine("Dictionary's load capacity: " + testDict.loadCapacity);
            testDict.Add(10, "P"); Console.WriteLine("Adding: 10-P");
            Console.WriteLine("Dictionary's underlying array length: " + testDict.underlyingArray.Length);
            Console.WriteLine("Dictionary's load capacity: " + testDict.loadCapacity);
            testDict.Add(8, "L"); Console.WriteLine("Adding: 8-K");
            Console.WriteLine("Dictionary's underlying array length: " + testDict.underlyingArray.Length);
            Console.WriteLine("Dictionary's load capacity: " + testDict.loadCapacity);
            testDict.Add(2, "K"); Console.WriteLine("Adding: 2-K");
            Console.WriteLine("Dictionary's underlying array length: " + testDict.underlyingArray.Length);
            Console.WriteLine("Dictionary's load capacity: " + testDict.loadCapacity);
            testDict.Add(90, "R"); Console.WriteLine("Adding: 90-R");
            Console.WriteLine("Dictionary's underlying array length: " + testDict.underlyingArray.Length);
            Console.WriteLine("Dictionary's load capacity: " + testDict.loadCapacity);
            Console.WriteLine("All Keys: " + string.Join(",", testDict.Keys.ToArray()));
            Console.WriteLine("All Values: " + string.Join(",", testDict.Values.ToArray()));
            Console.WriteLine("Expanding Array Test Suceeded");
            Console.WriteLine();
        }

        static void TestContains()
        {
            MyDictionary<char, bool> testDict = new MyDictionary<char, bool>();
            Console.WriteLine("Testing Contains Function...");
            Console.WriteLine();
            testDict.Add('A', true); Console.WriteLine("Adding: A-true");
            testDict.Add('G', true); Console.WriteLine("Adding: G-true");
            testDict.Add('L', false); Console.WriteLine("Adding: G-false");
            testDict.Add('R', false); Console.WriteLine("Adding: R-false");
            testDict.Add('Z', false); Console.WriteLine("Adding: Z-false");
            testDict.Add('K', true); Console.WriteLine("Adding: K-true");
            testDict.Add('D', false); Console.WriteLine("Adding: D-false");
            testDict.Add('O', true); Console.WriteLine("Adding: O-true");
            testDict.Add('P', false); Console.WriteLine("Adding: P-false");
            Debug.Assert(testDict.ContainsKey('A')); Debug.Assert(testDict.Contains(new KeyValuePair<char, bool>('A',true))); Console.WriteLine("Dictionary Contains: A-true");
            Debug.Assert(testDict.ContainsKey('G')); Debug.Assert(testDict.Contains(new KeyValuePair<char, bool>('G', true))); Console.WriteLine("Dictionary Contains: G-true");
            Debug.Assert(testDict.ContainsKey('L')); Debug.Assert(testDict.Contains(new KeyValuePair<char, bool>('L', false))); Console.WriteLine("Dictionary Contains: L-false");
            Debug.Assert(testDict.ContainsKey('R')); Debug.Assert(testDict.Contains(new KeyValuePair<char, bool>('R', false))); Console.WriteLine("Dictionary Contains: R-false");
            Debug.Assert(testDict.ContainsKey('Z')); Debug.Assert(testDict.Contains(new KeyValuePair<char, bool>('Z', false))); Console.WriteLine("Dictionary Contains: Z-false");
            Debug.Assert(testDict.ContainsKey('K')); Debug.Assert(testDict.Contains(new KeyValuePair<char, bool>('K', true))); Console.WriteLine("Dictionary Contains: K-true");
            Debug.Assert(testDict.ContainsKey('D')); Debug.Assert(testDict.Contains(new KeyValuePair<char, bool>('D', false))); Console.WriteLine("Dictionary Contains: D-false");
            Debug.Assert(testDict.ContainsKey('O')); Debug.Assert(testDict.Contains(new KeyValuePair<char, bool>('O', true))); Console.WriteLine("Dictionary Contains: O-true");
            Debug.Assert(testDict.ContainsKey('P')); Debug.Assert(testDict.Contains(new KeyValuePair<char, bool>('P', false))); Console.WriteLine("Dictionary Contains: P-false");

            Debug.Assert(!testDict.ContainsKey('T')); Console.WriteLine("Dictionary Does Not Contain key T");
            Debug.Assert(!testDict.Contains(new KeyValuePair<char, bool>('G', false))); Console.WriteLine("Dictionary Does not Contain Pair: G-false");

            Console.WriteLine("All Keys: " + string.Join(",", testDict.Keys.ToArray()));
            Console.WriteLine("All Values: " + string.Join(",", testDict.Values.ToArray()));
            Console.WriteLine("Contains Test Suceeded");
            Console.WriteLine();
        }

        static void TestTryGetValue()
        {
            MyDictionary<int, string> testDict = new MyDictionary<int, string>();
            Console.WriteLine("Testing TryGetValue Function...");
            Console.WriteLine();
            testDict.Add(1, "A"); Console.WriteLine("Adding: 1-A");
            testDict.Add(43, "B"); Console.WriteLine("Adding: 43-B");
            testDict.Add(7, "C"); Console.WriteLine("Adding: 7-C");
            testDict.Add(9, "C"); Console.WriteLine("Adding: 9-C");
            testDict.Add(50, "K"); Console.WriteLine("Adding: 50-K");
            testDict.Add(10, "P"); Console.WriteLine("Adding: 10-P");
            testDict.Add(80, "F"); Console.WriteLine("Adding: 80-F");
            testDict.Add(64, "J"); Console.WriteLine("Adding: 64-J");
            testDict.Add(13, "P"); Console.WriteLine("Adding: 13-P");
            string value1;
            string value2;
            string value3;
            Debug.Assert(testDict.TryGetValue(50, out value1)); Debug.Assert(value1.Equals("K")); Console.WriteLine("Found Key 50. It has an output value of " + value1);
            Debug.Assert(testDict.TryGetValue(13, out value2)); Debug.Assert(value2.Equals("P")); Console.WriteLine("Found Key 13. It has an output value of " + value2);
            Debug.Assert(!testDict.TryGetValue(2, out value3)); Console.WriteLine("Did not find Key 2. It has an output value of " + value3);

            Console.WriteLine("All Keys: " + string.Join(",", testDict.Keys.ToArray()));
            Console.WriteLine("All Values: " + string.Join(",", testDict.Values.ToArray()));
            Console.WriteLine("TryGetValue Test Suceeded");
            Console.WriteLine();
        }

        static void TestClear()
        {
            MyDictionary<int, string> testDict = new MyDictionary<int, string>();
            Console.WriteLine("Testing Clear Function...");
            Console.WriteLine();
            testDict.Add(1, "A"); Console.WriteLine("Adding: 1-A");
            testDict.Add(43, "B"); Console.WriteLine("Adding: 43-B");
            testDict.Add(7, "C"); Console.WriteLine("Adding: 7-C");
            testDict.Add(9, "L"); Console.WriteLine("Adding: 9-C");
            testDict.Add(50, "K"); Console.WriteLine("Adding: 50-K");
            testDict.Add(10, "P"); Console.WriteLine("Adding: 10-P");
            testDict.Add(8, "L"); Console.WriteLine("Adding: 8-l");
            testDict.Add(2, "K"); Console.WriteLine("Adding: 2-K");
            testDict.Add(90, "R"); Console.WriteLine("Adding: 90-R");
            testDict.Clear(); Console.WriteLine("Clearing dictionary...");
            Debug.Assert(testDict.underlyingArray.Length == 7); Debug.Assert(testDict.Count == 0); Debug.Assert(!testDict.ContainsKey(10));
            Console.WriteLine("All Keys: " + string.Join(",", testDict.Keys.ToArray()));
            Console.WriteLine("All Values: " + string.Join(",", testDict.Values.ToArray()));
            Console.WriteLine("Clear Test Suceeded");
            Console.WriteLine();
        }

        static void TestEnumerator()
        {
            MyDictionary<int, string> testDict = new MyDictionary<int, string>();
            Console.WriteLine("Testing GetEnumerator Function...");
            Console.WriteLine();
            testDict.Add(1, "A"); Console.WriteLine("Adding: 1-A");
            testDict.Add(43, "B"); Console.WriteLine("Adding: 43-B");
            testDict.Add(7, "C"); Console.WriteLine("Adding: 7-C");
            testDict.Add(9, "L"); Console.WriteLine("Adding: 9-C");
            testDict.Add(50, "K"); Console.WriteLine("Adding: 50-K");
            testDict.Add(10, "P"); Console.WriteLine("Adding: 10-P");
            testDict.Add(8, "L"); Console.WriteLine("Adding: 8-l");
            testDict.Add(2, "K"); Console.WriteLine("Adding: 2-K");
            testDict.Add(90, "R"); Console.WriteLine("Adding: 90-R");
            Console.WriteLine("Enumerating over values...");
            IEnumerator<KeyValuePair<int, string>> dictionaryEnumerator = testDict.GetEnumerator();
            while (dictionaryEnumerator.MoveNext())
            {
                Console.WriteLine("current Key: " + dictionaryEnumerator.Current.Key);
                Console.WriteLine("current Value: " + dictionaryEnumerator.Current.Value);
                Console.WriteLine();
            }
            Console.WriteLine("Get Enumerator Test Suceeded");
            Console.WriteLine();
        }
    }
}
