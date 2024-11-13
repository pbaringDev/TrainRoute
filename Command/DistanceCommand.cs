using System;
using System.Collections.Generic;
using System.Text;
using TrainRoute.DLL.Calculator;
using TrainRoute.DLL.Model;

namespace TrainRoute.Command
{
    class DistanceCommand : ICommand
    {
        private readonly Dictionary<string, List<Route>> routes;

        public DistanceCommand(Dictionary<string, List<Route>> routes)
        {
            this.routes = routes;
        }

        public void Execute(string input)
        {
            var distanceCalc = new DistanceCalculator(routes);
            var routeInput = input.ToCharArray();
            var distance = distanceCalc.GetRouteDistance(routeInput);

            if (distance.HasValue)
                Console.WriteLine(distance);
            else
                Console.WriteLine($"Route does not exist");
        }
    }
}
