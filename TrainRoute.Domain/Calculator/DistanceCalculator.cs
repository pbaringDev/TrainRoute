using System.Collections.Generic;
using System.Linq;
using TrainRoute.Domain.Interfaces;
using TrainRoute.Domain.Model;

namespace TrainRoute.Domain.Calculator
{
    public class DistanceCalculator : IDistanceCalculator
    {
        private readonly Dictionary<string, List<Route>> _routeMap;
        public DistanceCalculator(Dictionary<string, List<Route>> routeMap)
        {
            _routeMap = routeMap;
        }
        public int? GetRouteDistance(char[] route)
        {
            int distance = 0;

            for (int i = 0; i < route.Length - 1; i++)
            {
                string start = route[i].ToString();
                string end = route[i + 1].ToString();

                var routeFound = _routeMap[start].FirstOrDefault(r => r.End == end);
                if (routeFound == null)
                {
                    return null;
                }

                distance += routeFound.Distance;
            }
            return distance;
        }
    }
}
