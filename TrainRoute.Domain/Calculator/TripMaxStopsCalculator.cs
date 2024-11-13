using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainRoute.Domain.Interfaces;
using TrainRoute.Domain.Model;

namespace TrainRoute.Domain.Calculator
{
    public class TripMaxStopsCalculator: ITripCalculator
    {
        private readonly Dictionary<string, List<Route>> _routeMap;
        public TripMaxStopsCalculator(Dictionary<string, List<Route>> routeMap)
        {

            _routeMap = routeMap;
        }


        public int CountTrips(string start, string end, int limiter)
        {
            int tripCount = 0;
            var maxStops = limiter;
            CountTripsRecursive(start, end, 0, maxStops, ref tripCount);
            return tripCount;
        }

        //Test #6: Number of trips from C to C with maximum 3 stops is 2 ( C=>D=>C, C=>E=>B=>C ) 
        private void CountTripsRecursive(string start, string end, int stops, int maxStops, ref int tripCount)
        {
            var routes = _routeMap[start].Where(x => stops <= maxStops);
            stops++;
            foreach (var route in routes)
            {
                if (route.End.Equals(end))
                {
                    tripCount++;
                }
                CountTripsRecursive(route.End, end, stops, maxStops, ref tripCount);
            }
        }

    }
}
