using System.Collections.Generic;
using TrainRoute.Domain.Calculator;
using TrainRoute.Domain.Model;
using Xunit;

namespace TrainRoute.Test.Tests
{
    public class DistanceCalculatorTests
    {
        private readonly Dictionary<string, List<Route>> _routeMap;

        public DistanceCalculatorTests()
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
        public void GetRouteDistance_ValidRoute_ReturnsCorrectDistance()
        {   
            var calculator = new DistanceCalculator(_routeMap);
            var route = new char[] { 'A', 'B', 'C' };
            
            var distance = calculator.GetRouteDistance(route);
                        
            Assert.Equal(9, distance);
        }

        [Fact]
        public void GetRouteDistance_InvalidRoute_ReturnsNull()
        {
            
            var calculator = new DistanceCalculator(_routeMap);
            var route = new char[] { 'A', 'D', 'B' }; // No route from D to B in sample data

            
            var distance = calculator.GetRouteDistance(route);

            
            Assert.Null(distance);
        }

        [Fact]
        public void GetRouteDistance_SingleNodeRoute_ReturnsZero()
        {
            
            var calculator = new DistanceCalculator(_routeMap);
            var route = new char[] { 'A' }; // Single node, no distance to travel

            
            var distance = calculator.GetRouteDistance(route);

            
            Assert.Equal(0, distance);
        }

        [Fact]
        public void GetRouteDistance_EmptyRoute_ReturnsZero()
        {
            
            var calculator = new DistanceCalculator(_routeMap);
            var route = new char[] { }; // Empty route, no distance to travel

            
            var distance = calculator.GetRouteDistance(route);

            
            Assert.Equal(0, distance);
        }

        [Fact]
        public void GetRouteDistance_AnotherValidRoute_ReturnsCorrectDistance()
        {
            
            var calculator = new DistanceCalculator(_routeMap);
            var route = new char[] { 'A', 'E', 'B', 'C', 'D' };

            
            var distance = calculator.GetRouteDistance(route);

            
            Assert.Equal(22, distance); // 7 + 3 + 4 + 8 = 22
        }
    }
}
