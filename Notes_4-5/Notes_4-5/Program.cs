using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes_4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //flexible and constant time. can use objects 
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            myDict[1324] = "Jamie";
            myDict[43243] = "Ryan";
            /*
            dictionary only stores what you give it. therefore when you create a large value
            and it wont create an entire large array in memory
            */

            Dictionary<string, string> myDict2 = new Dictionary<string, string>();
            myDict2["hello"] = "bob";
            myDict2["hi"] = "joe";
            Console.WriteLine(myDict2["hello"]);
           
        }
        
    }
    class Person : System.Object
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            Person other = (Person)obj;
            return this.FirstName == other.FirstName && this.LastName == other.LastName;
        }
    }
}
