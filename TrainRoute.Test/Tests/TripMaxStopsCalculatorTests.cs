using System;
using System.Collections.Generic;
using System.Text;
using TrainRoute.Domain.Calculator;
using TrainRoute.Domain.Model;
using Xunit;

namespace TrainRoute.Test.Tests
{
    public class TripMaxStopsCalculatorTests
    {

        private readonly Dictionary<string, List<Route>> _routeMap;
        public TripMaxStopsCalculatorTests()
        {
            // Initialize the route map with sample data
            //[A,B,5][B,C,4][C,D,8][D,C,8][D,E,6][A,D,5][C,E,2][E,B,3][A,E,7]
            _routeMap = new Dictionary<string, List<Route>>
            {
                { "A", new List<Route>
                    {
                        new Route(){ Start = "A", End = "B", Distance = 5},
                        new Route(){ Start = "A", End = "D", Distance = 5},
                        new Route(){ Start = "A", End = "E", Distance = 7}
                    }
                },

                { "B", new List<Route>
                    {
                        new Route(){ Start = "B", End = "C", Distance = 4}
                    }
                },
                { "C", new List<Route>
                    {
                        new Route(){ Start = "C", End = "D", Distance = 8},
                        new Route(){ Start = "C", End = "E", Distance = 2}
                    }
                },
                { "D", new List<Route>
                    {
                        new Route(){ Start = "D", End = "C", Distance = 8},
                        new Route(){ Start = "D", End = "E", Distance = 6}
                    }
                },
                { "E", new List<Route>
                    {
                        new Route(){ Start = "E", End = "B", Distance = 3}
                    }
                }
            };
        }

        [Fact]
        public void CountTrips_MaxStops_ReturnsCorrectCount()
        {
            var calculator = new TripMaxStopsCalculator(_routeMap);

            var tripCount = calculator.CountTrips("A", "C", 3);

            Assert.Equal(3, tripCount); // A=>B=>C, A=>D=>C, A=>E=>B=>C
        }

        [Fact]
        public void CountTrips_MaxStops_NoValidRoute_ReturnsZero()
        {
            var calculator = new TripMaxStopsCalculator(_routeMap);

            var tripCount = calculator.CountTrips("A", "F",5);

            Assert.Equal(0, tripCount); // No route to "F" in the map
        }

        [Fact]
        public void CountTrips_MaxStops_StartEqualsEnd_ReturnsCorrectCount()
        {
            var calculator = new TripMaxStopsCalculator(_routeMap);

            var tripCount = calculator.CountTrips("C", "C", 3);

            Assert.Equal(2, tripCount); // C=>D=>C, C=>E=>B=>C 
        }
    }
}
