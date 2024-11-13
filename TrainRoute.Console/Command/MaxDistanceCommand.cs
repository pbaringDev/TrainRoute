using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainRoute.Domain.Calculator;
using TrainRoute.Domain.Model;

namespace TrainRoute.Command
{
    internal class MaxDistanceCommand: ICommand
    {
        private readonly Dictionary<string, List<Route>> routes;
        public MaxDistanceCommand(Dictionary<string, List<Route>> routes)
        {
            this.routes = routes;
        }

        public void Execute(string input)
        {
            var tripCalc = new TripMaxDistanceCalculator(routes);
            var (start, end, maxDistance) = ParseRouteAndValue(input);
            var tripsNumber = tripCalc.CountTrips(start, end, maxDistance);

            Console.WriteLine(tripsNumber);
        }

        private (string start, string end, int value) ParseRouteAndValue(string inputs)
        {
            var routeInput = inputs.ToCharArray();
            var start = routeInput[0].ToString();
            var end = routeInput[1].ToString();
            var value = int.Parse(new string(inputs.Where(char.IsDigit).ToArray()));

            return (start, end, value);
        }
    }
}
