using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6
{
    class Node : IComparable<Node>
    {
        public char Name { get; set; }
        public double[] Coordinates { get; set; }
        public Node[] Connections { get; set; }
        public double Heuristic { get; set; }
        public double CostSoFar { get; set; }
        public double TotalEstimatedCost { get; set; }
        public Node CameFrom { get; set; }

        public int CompareTo(Node obj)
        {
            if(this.TotalEstimatedCost > obj.TotalEstimatedCost)
            {
                return -1;
            }
            else if (this.TotalEstimatedCost < obj.TotalEstimatedCost)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
