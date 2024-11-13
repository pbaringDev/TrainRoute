using System;
using System.Collections.Generic;
using System.Text;

namespace TrainRoute.Domain.Interfaces
{
    public interface ITripCalculator
    {
        public int CountTrips(string start, string end, int limiter);
    }
}
