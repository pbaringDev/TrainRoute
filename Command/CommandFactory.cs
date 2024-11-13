using System;
using System.Collections.Generic;
using TrainRoute.DLL.Model;

namespace TrainRoute.Command
{
    class CommandFactory
    {
        private readonly Dictionary<string, List<Route>> routes;

        public CommandFactory(Dictionary<string, List<Route>> routes)
        {
            this.routes = routes;
        }

        public ICommand GetCommand(string commandType)
        {

            switch (commandType)
            {
                case "a":
                    {
                        return new DistanceCommand(routes);
                    }
                case "b":
                    {
                        return new MaxStopsCommand(routes);
                    }
                case "c":
                    {
                        return new ExactStopsCommand(routes);
                    }
                case "d":
                    {
                        return new ShortestRouteCommand(routes);
                    }
                case "e":
                    {
                        return new MaxDistanceCommand(routes);
                    }
                default:
                    throw new ArgumentException("Invalid command");
            }
        }
    }

}
