using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TrainRoute.Calculator;
using TrainRoute.Model;
using TrainRoute.Service;

namespace TrainRoute
{
    internal class Program
    {
        static Dictionary<string, List<Route>> routes = new Dictionary<string, List<Route>>();
        static string command;
        static string inputs;
        static void Main(string[] args)
        {
            string filePath = @"Data\Input.txt";

            ShowOption();
            GetCommand();
            LoadTrainRoutes(filePath);
            ProcessInput();
            ProcessCommand();

        }
        static void LoadTrainRoutes(string filePath)
        {
            FileService fileService = new FileService();
            routes = fileService.LoadRoutesFromFile(filePath);
            if (routes == null || routes.Count() == 0)
            {
                Environment.Exit(0);
            }
        }

        static void ShowOption()
        {
            Console.WriteLine();
            Console.WriteLine("Here are the list of possible commands:");
            Console.WriteLine();
            Console.WriteLine("a -Find the distance of a route");
            Console.WriteLine("b -Get the number of trips between two towns with a maximum number of stops");
            Console.WriteLine("c -Get the number of trips between two towns with an exact number of stops");
            Console.WriteLine("d -Find the shortest route between two towns");
            Console.WriteLine("e -Get the number of trips between two town with less than a distance of");
        }



        static void GetCommand()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter your command");
            command = Console.ReadLine();
        }

        static void ProcessInput()
        {
            Console.WriteLine("Please enter input for selected command");

            if (command == "a")
            {
                Console.WriteLine("Example input for finding the distance of the route A=>B=>C");
                Console.WriteLine("ABC");
                Console.WriteLine("Please enter input");
                inputs = Console.ReadLine();


                var regex = new Regex("[a-zA-Z]+");
                if (!regex.IsMatch(inputs))
                {
                    Console.WriteLine("Input should be consists of letters only");
                    Environment.Exit(1);
                }

            }
            else if (command == "b" || command == "c" || command == "e")
            {
                Console.WriteLine("Input must consists of start and end towns and number of trips/distance");
                Console.WriteLine("Eg. AC4");
                Console.WriteLine("Please enter input");
                inputs = Console.ReadLine();

                var regex = new Regex("^[a-zA-Z][a-zA-Z0-9]*$");
                if (!regex.IsMatch(inputs))
                {
                    Console.WriteLine("Input must consists of start and end of station followed by number of trips/distance");
                    Environment.Exit(1);
                }
            }
            else if (command == "d")
            {
                var regex = new Regex(@"^[a-zA-Z][a-zA-Z]$");
                if (!regex.IsMatch(inputs))
                {
                    Console.WriteLine("Input must consist of a start and end station.");
                    Console.WriteLine("Eg. AC");
                    Environment.Exit(1);
                }
            }
            else
            {
                Console.WriteLine("Cannot read the selected command");
                Environment.Exit(1);

            }
        }

        static void ProcessCommand()
        {
            if (command == "a")
            {
                //call calculator for finding the distance of a route
                DistanceCalculator distanceCalc = new DistanceCalculator(routes);
                var routeInput = inputs.ToCharArray();

                var distance = distanceCalc.GetRouteDistance(routeInput);
                var stringRoute = string.Join("=>", routeInput);
                if (distance.HasValue)
                {
                    Console.WriteLine($"The distance of the route {stringRoute} is {distance}");
                }
                else
                {
                    Console.WriteLine($"Route {stringRoute} doesnt exists");
                }

            }
            else if (command == "b")
            {
                //trip with max stops
                var tripCalc = new TripWithConditionCalculator(routes);
                var routeInput = inputs.ToCharArray();
                var start = routeInput[0].ToString();
                var end = routeInput[1].ToString();
                var maxStops = int.Parse(string.Concat(inputs.Where(Char.IsDigit).ToArray()));
                var tripsNumber = tripCalc.FindTrips(start, end, maxStops, 0, int.MaxValue, false);

                Console.WriteLine($"TNumber of trips from {start} to {end} with maximum {maxStops} stops is {tripsNumber}");
            }
            else if (command == "c")
            {
                //exact number of stops
                var tripCalc = new TripWithConditionCalculator(routes);
                var routeInput = inputs.ToCharArray();
                var start = routeInput[0].ToString();
                var end = routeInput[1].ToString();
                var exactStops = int.Parse(string.Concat(inputs.Where(Char.IsDigit).ToArray()));
                var tripsNumber = tripCalc.FindTrips(start, end, int.MaxValue, exactStops, int.MaxValue, true);
                Console.WriteLine($"Number of trips from {start} to {end} with exactly {exactStops} stops is {tripsNumber}");
            }
            else if (command == "d")
            {
                var shortestCalc = new ShortestRouteCalculator(routes);
                var routeInput = inputs.ToCharArray();
                var start = routeInput[0].ToString();
                var end = routeInput[1].ToString();
                var length = shortestCalc.FindShortestRoute(start, end);

                Console.WriteLine($"The length of the shortest route from {start} to {end} is {length}");
            }
            else if (command == "e")
            {
                //with max distance
                var tripCalc = new TripWithConditionCalculator(routes);
                var routeInput = inputs.ToCharArray();
                var start = routeInput[0].ToString();
                var end = routeInput[1].ToString();
                var maxDistance = int.Parse(string.Concat(inputs.Where(Char.IsDigit).ToArray()));
                var tripsNumber = tripCalc.FindTrips(start, end, int.MaxValue, 0, maxDistance, false);
                Console.WriteLine($"Number of trips from {start} to {end} with distance less than {maxDistance} is {tripsNumber}");
            }
            else
            {

                Console.WriteLine("Cannot process command");
            }

        }

    }



}
