using System;
using System.Collections.Generic;
using System.Text;

namespace TrainRoute.Domain.Interfaces
{
    public interface IDistanceCalculator
    {
        public int? GetRouteDistance(char[] route);
    }
}
