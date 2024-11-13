using System;
using System.Collections.Generic;
using System.Text;

namespace TrainRoute.Domain.Interfaces
{
    public interface ITripWithConditionCalculator
    {
        int FindTrips(string start, string end, int maxStops, int exactStops, int maxDistance, bool countExactStops);
        void FindTripRecursive(string current, string end, int stops, int distance, ref int trips, int maxStops, int exactStops, int maxDistance, bool countExactStops);
    }
}
