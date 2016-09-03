using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes_2_16
{
    class Program
    {
        static void Main(string[] args)
        {
            //multiplicative identity: when u stop

        }
        /* 
            B determines how much we recurse
            recurance relationship: function that describes how muh work gets done, given a certain input

            multiply(n) = 1 + multiply(n-1)
            2 times: multiply(n-1) = 1 + multiply(n-1-1)
            3 times: multiply(n-2) = 1 + multiply(n-3)

            i times: multiply(n) = i + multiply(n - i)
            amount of times you will have to recurse is n-i times

            2^n counts the number of bits 
            when you divide each time

            div(n) = 1 + div (n/2)
            or can be written like
            n = 2^k
            div(2^k) = 1 + div(2^k-1)
            therefore:
            div(2^k) = i + div(2^k-i)
            *log[base 2](n) = k

            dividing and conquering
            - dividing it down and solving for 1 is much simpler
            - half the size is more than half than simple
            - this is because half of a number squared is less 

            Master theorem: T(n) = aT(n/b) + f(n)
        spliting up^          ^ merging back
            merging back takes linear time 
           */
        static int Multiply(int a, int b)
        {
            if (b == 1)
                return a;
            return Multiply(a, b - 1) + a;
        }
    }
}
