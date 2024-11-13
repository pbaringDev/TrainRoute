using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainRoute.Domain.Calculator;
using TrainRoute.Domain.Model;

namespace TrainRoute.Command
{
    class ExactStopsCommand : ICommand
    {


        private readonly Dictionary<string, List<Route>> routes;

        public ExactStopsCommand(Dictionary<string, List<Route>> routes)
        {
            this.routes = routes;
        }

        public void Execute(string input)
        {
            var tripCalc = new TripExactStopCalculator(routes);
            var (start, end, exactStops) = ParseRouteAndValue(input);
            var tripsNumber = tripCalc.CountTrips(start, end, exactStops);

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
