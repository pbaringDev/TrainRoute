using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TrainRoute.Command;
using TrainRoute.DLL.Model;
using TrainRoute.DLL.Service;

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

            var commandFactory = new CommandFactory(routes);
            var selectedCommand = commandFactory.GetCommand(command);
            selectedCommand.Execute(inputs);

        }
        static void LoadTrainRoutes(string filePath)
        {
            var fileService = new FileService();
            routes = fileService.LoadRoutesFromFile(filePath);

            if (routes == null || routes.Count == 0)
            {
                Console.WriteLine("No routes found. Exiting...");
                Environment.Exit(0);
            }
        }

        static void ShowOption()
        {
            Console.WriteLine("\nAvailable Commands:");
            Console.WriteLine("a - Find the distance of a route");
            Console.WriteLine("b - Get the number of trips with a maximum number of stops");
            Console.WriteLine("c - Get the number of trips with an exact number of stops");
            Console.WriteLine("d - Find the shortest route between two towns");
            Console.WriteLine("e - Get the number of trips with a distance limit\n");
        }



        static void GetCommand()
        {
            Console.WriteLine("Please enter your command");
            command = Console.ReadLine();
        }

        static void ProcessInput()
        {
            Console.WriteLine("Please enter input for the selected command:");

            switch (command)
            {
                case "a":
                    ShowDistanceInputInstructions();
                    ValidateInput("^[A-Za-z]+$");
                    break;
                case "b":
                case "c":
                case "e":
                    ShowTripInputInstructions();
                    ValidateInput("^[A-Za-z][A-Za-z0-9]*$");
                    break;
                case "d":
                    ShowShortestRouteInputInstructions();
                    ValidateInput("^[A-Za-z]{2}$");
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    Environment.Exit(1);
                    break;
            }
        }
        static void ShowDistanceInputInstructions()
        {
            Console.WriteLine("Example input for finding the distance of route A=>B=>C: ABC");
            Console.WriteLine("Enter input:");
            inputs = Console.ReadLine();
        }

        static void ShowTripInputInstructions()
        {
            Console.WriteLine("Input format: Start town, end town, and number of trips/distance (e.g., AC4)");
            Console.WriteLine("Enter input:");
            inputs = Console.ReadLine();
        }

        static void ShowShortestRouteInputInstructions()
        {
            Console.WriteLine("Input format: Start and end station (e.g., AC)");
            inputs = Console.ReadLine();
        }

        static void ValidateInput(string pattern)
        {
            if (!Regex.IsMatch(inputs, pattern))
            {
                Console.WriteLine("Invalid input format.");
                Environment.Exit(1);
            }
        }


    }



}
