using System;
using System.Collections.Generic;
using System.Text;
using TrainRoute.Model;

namespace TrainRoute.Calculator
{
    public class TripWithConditionCalculator
    {
        private readonly Dictionary<string, List<Route>> _routeMap;
        public TripWithConditionCalculator(Dictionary<string, List<Route>> routeMap) { 
        
            _routeMap = routeMap;
        }

        public int FindTrips(string start, string end, int maxStops, int exactStops, int maxDistance, bool countExactStops)
        {
            int trips = 0;
            FindTripRecursive(start, end, 0, 0, ref trips, maxStops, exactStops, maxDistance, countExactStops);
            return trips;
        }

        public void FindTripRecursive(string current, string end, int stops, int distance, ref int trips, int maxStops, int exactStops, int maxDistance, bool countExactStops)
        {
            if (stops > maxStops || distance >= maxDistance) return;

            if ((countExactStops && stops == exactStops && current == end) ||
                (!countExactStops && current == end && stops <= maxStops))
            {
                trips++;
            }

            if (_routeMap.ContainsKey(current))
            {
                foreach (var route in _routeMap[current])
                {
                    FindTripRecursive(route.End, end, stops + 1, distance + route.Distance, ref trips, maxStops, exactStops, maxDistance, countExactStops);
                }
            }
        }
    }
}
