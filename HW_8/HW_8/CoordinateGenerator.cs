using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8
{
    class CoordinateGenerator : IEnumerable<Point>
    {
        Random rand;
        bool continueGenerator;
        public List<Point> CoordinateList {get; set;}
        public CoordinateGenerator()
        {
            rand = new Random();
            continueGenerator = true;
        }
        public IEnumerator<Point> GetEnumerator()
        {
            while (continueGenerator)
            {
                Point point = new Point { X = rand.Next(0,20), Y = rand.Next(0,20) };
                yield return point;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
