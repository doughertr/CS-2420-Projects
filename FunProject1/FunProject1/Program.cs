using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LinearSearch(new int [] {1,9,6,0,3,6,2 }, 0));
            Console.ReadLine();
        }
        static int LinearSearch(int[] arr, int val)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] == val)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
