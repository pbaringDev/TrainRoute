using System;
using System.Collections.Generic;
using System.Text;
using TrainRoute.Model;

namespace TrainRoute.Calculator
{
    public class ShortestRouteCalculator
    {
        private readonly Dictionary<string, List<Route>> _routeMap;
        public ShortestRouteCalculator(Dictionary<string, List<Route>> routeMap)
        {
            _routeMap = routeMap;
        }

        public int? FindShortestRoute(string start, string end)
        {
            var shortestDistance = new Dictionary<string, int>();
            foreach (var node in _routeMap.Keys) shortestDistance[node] = int.MaxValue;
            shortestDistance[start] = 0;

            var queue = new Queue<string>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var route in _routeMap[current])
                {
                    int newDist = shortestDistance[current] + route.Distance;
                    if (newDist < shortestDistance[route.End])
                    {
                        shortestDistance[route.End] = newDist;
                        queue.Enqueue(route.End);
                    }
                }
            }
            return shortestDistance[end] == int.MaxValue ? (int?)null : shortestDistance[end];
        }
    }
}
