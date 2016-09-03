using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool willContinue = true;
            int testNum = 1;

            Node[] nodeList;
            AStarAlgorithm star;
            IEnumerator<char> AStarEnum;

            while (willContinue)
            {
                nodeList = BuildNodeList();
                star = new AStarAlgorithm(nodeList);

                Console.WriteLine("=======| Test Number " + testNum + " |=======");
                Console.WriteLine();
                star.Traverse();
                Console.WriteLine();
                Console.WriteLine("Node Traversal Order:");
                AStarEnum = star.GetEnumerator();
                while (AStarEnum.MoveNext())
                    Console.WriteLine(AStarEnum.Current);
                Console.WriteLine();
                Console.WriteLine("===============================");
                Console.WriteLine();
                Console.Write("Do another test? (y/n): ");
                if (!char.ToUpper(Console.ReadKey().KeyChar).Equals('Y'))
                    willContinue = false;
                testNum++;
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        static Node[] BuildNodeList()
        {
            Node[] nodeList = new Node[16];
            char[] letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P' };
            Dictionary<char, double[]> nodeDictionary = new Dictionary<char, double[]>();

            nodeDictionary.Add('A', new double[] { -19, 11 });   //0
            nodeDictionary.Add('B', new double[] { -13, 13 });  //1
            nodeDictionary.Add('C', new double[] { 4, 14 });    //2
            nodeDictionary.Add('D', new double[] { -4, 12 });   //3
            nodeDictionary.Add('E', new double[] { -8, 3 });    //4
            nodeDictionary.Add('F', new double[] { -18, 1 });   //5
            nodeDictionary.Add('G', new double[] { -12, -8 });  //6
            nodeDictionary.Add('H', new double[] { 12, -9 });   //7
            nodeDictionary.Add('I', new double[] { -18, -11 }); //8
            nodeDictionary.Add('J', new double[] { -4, -11 });  //9
            nodeDictionary.Add('K', new double[] { -12, -14 }); //10
            nodeDictionary.Add('L', new double[] { 2, -18 });   //11
            nodeDictionary.Add('M', new double[] { 18, -13 });  //12
            nodeDictionary.Add('N', new double[] { 4, -9 });    //13
            nodeDictionary.Add('O', new double[] { 22, 11 });   //14
            nodeDictionary.Add('P', new double[] { 18, 3 });    //15
            for (int i = 0; i < letters.Length; i++)
            {
                nodeList[i] = new Node { Name = letters[i], Coordinates = nodeDictionary[letters[i]] };
            }

            nodeList[0].Connections = new Node[] { nodeList[1], nodeList[4] };
            nodeList[1].Connections = new Node[] { nodeList[0], nodeList[3] };
            nodeList[2].Connections = new Node[] { nodeList[3], nodeList[4], nodeList[15] };
            nodeList[3].Connections = new Node[] { nodeList[1], nodeList[2], nodeList[4] };
            nodeList[4].Connections = new Node[] { nodeList[0], nodeList[2], nodeList[3], nodeList[6], nodeList[9], nodeList[13], nodeList[7] };
            nodeList[5].Connections = new Node[] { nodeList[6], nodeList[8] };
            nodeList[6].Connections = new Node[] { nodeList[4], nodeList[5], nodeList[9] };
            nodeList[7].Connections = new Node[] { nodeList[4], nodeList[13], nodeList[15] };
            nodeList[8].Connections = new Node[] { nodeList[5], nodeList[10] };
            nodeList[9].Connections = new Node[] { nodeList[4], nodeList[6], nodeList[13], nodeList[10], nodeList[11] };
            nodeList[10].Connections = new Node[] { nodeList[8], nodeList[9], nodeList[11] };
            nodeList[11].Connections = new Node[] { nodeList[9], nodeList[10], nodeList[12] };
            nodeList[12].Connections = new Node[] { nodeList[11], nodeList[14], nodeList[15] };
            nodeList[13].Connections = new Node[] { nodeList[4], nodeList[7], nodeList[9] };
            nodeList[14].Connections = new Node[] { nodeList[12], nodeList[15] };
            nodeList[15].Connections = new Node[] { nodeList[2], nodeList[7], nodeList[14], nodeList[12] };
            return nodeList;
        }
    }
}
