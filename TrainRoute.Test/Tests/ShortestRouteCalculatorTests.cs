using System;
using System.Collections.Generic;
using System.Text;
using TrainRoute.Domain.Calculator;
using TrainRoute.Domain.Model;
using Xunit;

namespace TrainRoute.Test.Tests
{
    public class ShortestRouteCalculatorTests
    {
        private readonly Dictionary<string, List<Route>> _routeMap;
        public ShortestRouteCalculatorTests()
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
        public void FindShortestRoute_ValidRoute_ReturnsCorrectDistance()
        {
            var calculator = new ShortestRouteCalculator(_routeMap);

            var shortestDistance = calculator.FindShortestRoute("A", "C");

            Assert.Equal(9, shortestDistance); // A->B->C is the shortest route
        }

        [Fact]
        public void FindShortestRoute_NoRoute_ReturnsNull()
        {
            var calculator = new ShortestRouteCalculator(_routeMap);

            var shortestDistance = calculator.FindShortestRoute("A", "F"); // "F" is not in the route map

            Assert.Null(shortestDistance);
        }

        [Fact]
        public void FindShortestRoute_SameStartAndEnd_ReturnsZero()
        {
            var calculator = new ShortestRouteCalculator(_routeMap);

            var shortestDistance = calculator.FindShortestRoute("B", "B");
            Assert.Equal(9, shortestDistance);
        }

        [Fact]
        public void FindShortestRoute_DifferentRoute_ReturnsCorrectDistance()
        {
            var calculator = new ShortestRouteCalculator(_routeMap);

            var shortestDistance = calculator.FindShortestRoute("C", "E");

            Assert.Equal(2, shortestDistance); // C->E is the shortest route
        }
    }


}
