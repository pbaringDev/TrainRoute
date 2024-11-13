using System;
using System.Collections.Generic;
using System.Text;
using TrainRoute.DLL.Calculator;
using TrainRoute.DLL.Model;

namespace TrainRoute.Command
{
    class ShortestRouteCommand:ICommand
    {
        private readonly Dictionary<string, List<Route>> routes;
        public ShortestRouteCommand(Dictionary<string, List<Route>> routes)
        {
            this.routes = routes;
        }
        
        public void Execute(string input)
        {
            var shortestCalc = new ShortestRouteCalculator(routes);
            var start = input[0].ToString();
            var end = input[1].ToString();
            var length = shortestCalc.FindShortestRoute(start, end);

            Console.WriteLine(length);
        }
    }
}
