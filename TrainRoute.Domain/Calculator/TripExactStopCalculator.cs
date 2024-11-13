using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainRoute.Domain.Interfaces;
using TrainRoute.Domain.Model;

namespace TrainRoute.Domain.Calculator
{
    public class TripExactStopCalculator : ITripCalculator
    {
        private readonly Dictionary<string, List<Route>> _routeMap;
        public TripExactStopCalculator(Dictionary<string, List<Route>> routeMap)
        {

            _routeMap = routeMap;
        }
        public int CountTrips(string start, string end, int limiter)
        {
            int tripCount = 0;
            var exactStop = limiter;
            CountTripsRecursive(start, end, 0, exactStop, ref tripCount);
                return tripCount;
        }

        //Test #7: Number of trips from A to C with exactly 4 stops is 3 ( A=>B=>C=>D=>C, A=>D=>C=>D=>C, A=>D=>E=>B=>C )
        private void CountTripsRecursive(string start, string end, int stops, int exactStop, ref int tripCount)
        {
            if (stops <= exactStop)
            {
                var routes = _routeMap[start];
                stops++;
                foreach (var route in routes)
                {
                    if (route.End.Equals(end) && stops == exactStop)
                    {
                        tripCount++;
                    }
                    CountTripsRecursive(route.End, end, stops, exactStop, ref tripCount);
                }
            }

        }

    }
}
