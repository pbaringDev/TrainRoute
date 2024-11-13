using System.Collections.Generic;
using System.Linq;
using TrainRoute.Domain.Interfaces;
using TrainRoute.Domain.Model;

namespace TrainRoute.Domain.Calculator
{
    public class TripMaxDistanceCalculator : ITripCalculator
    {
        private readonly Dictionary<string, List<Route>> _routeMap;
        public TripMaxDistanceCalculator(Dictionary<string, List<Route>> routeMap)
        {

            _routeMap = routeMap;
        }


        public int CountTrips(string start, string end, int limiter)
        {
            int tripCount = 0;
            var maxDistance = limiter;
            CountTripsRecursive(start, end, 0, maxDistance, ref tripCount);
            return tripCount;
        }

        private void CountTripsRecursive(string start, string end, int distance, int maxDistance, ref int tripCount)
        {
            var routes = _routeMap[start].Where(x => distance <= maxDistance);
            
            foreach (var route in routes)
            {
                distance += route.Distance;
                if (route.End.Equals(end))
                {
                    tripCount++;
                }
                CountTripsRecursive(route.End, end, distance, maxDistance, ref tripCount);
            }
        }
    }
}
