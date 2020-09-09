using System;
using System.Collections.Generic;

namespace AcyclicGraphPathFinder
{
    class Program
    {
        static void Main()
        {
            //var testData = new List<(int, int)>
            //{
            //    (1,22), (1,21),
            //    (21,32), (22,33), (22,34), (22,35), (22,36), (21,37),
            //    (31,41), (32,41),(33,42), (34,43), (36,43), (37,51), (36,44), (32,42),
            //    (41,51), (42,51), (43,51), (44,51),
            //    (51,52),
            //};

            //var testData = new List<(int, int)>{ (1,2), (2,3), (1,3)};

            var testData = new List<(int, int)>
            {
                (1,3), (2,3), (1,2), (3,4), (4,5)
            };

            var graphService = new GraphService();

            var results = graphService.FindAllPaths(testData, 1, 5);

            foreach (var result in results)
            {
                result.Reverse();
                Console.WriteLine(string.Join(",", result));
            }

            Console.ReadLine();
        }
    }
}
