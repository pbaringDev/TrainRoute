using System;
using System.Collections.Generic;
using TrainRoute.Domain.Interfaces;
using TrainRoute.Domain.Model;

namespace TrainRoute.Domain.Calculator
{
    public class ShortestRouteCalculator: IShortestRouteCalculator
    {
        private readonly Dictionary<string, List<Route>> _routeMap;
        public ShortestRouteCalculator(Dictionary<string, List<Route>> routeMap)
        {
            _routeMap = routeMap;
        }

        public int? FindShortestRoute(string start, string end)
        {
            if (!_routeMap.ContainsKey(start) || !_routeMap.ContainsKey(end))
            {
                return null;
            }


            var shortestDistance = new Dictionary<string, int>();
            foreach (var node in _routeMap.Keys)
            {
                shortestDistance[node] = int.MaxValue;
            }

            var queue = new Queue<(string Node, int Distance)>();
            queue.Enqueue((start, 0));
            int minDistance = int.MaxValue;

            while (queue.Count > 0)
            {
                var (currentNode, currentDistance) = queue.Dequeue();

                // Check if we have reached the end node
                if (currentNode == end && currentDistance > 0)
                {
                    minDistance = Math.Min(minDistance, currentDistance);
                }

                // Process each neighboring route
                if (_routeMap.ContainsKey(currentNode))
                {
                    foreach (var route in _routeMap[currentNode])
                    {
                        int newDistance = currentDistance + route.Distance;
                        if (newDistance < minDistance)
                        {
                            queue.Enqueue((route.End, newDistance));
                        }
                    }
                }
            }

            return minDistance == int.MaxValue ? (int?)null : minDistance;
        }
    }
}
