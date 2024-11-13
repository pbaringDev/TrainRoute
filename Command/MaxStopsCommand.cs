using System;
using System.Collections.Generic;
using System.Linq;
using TrainRoute.DLL.Calculator;
using TrainRoute.DLL.Model;

namespace TrainRoute.Command
{
    class MaxStopsCommand : ICommand
    {
        private readonly Dictionary<string, List<Route>> routes;

        public MaxStopsCommand(Dictionary<string, List<Route>> routes)
        {
            this.routes = routes;
        }

        public void Execute(string input)
        {
            var tripCalc = new TripMaxStopsCalculator(routes);
            var start = input[0].ToString();
            var end = input[1].ToString();
            var maxStops = int.Parse(string.Concat(input.Where(char.IsDigit).ToArray()));
            var tripsCount = tripCalc.CountTrips(start, end, maxStops);

            Console.WriteLine(tripsCount);
        }
    }
}
