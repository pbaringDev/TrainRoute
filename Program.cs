using System;
using System.Collections.Generic;
using System.IO;

namespace TrainRoute
{
    internal class Program
    {
        static List<Route> routes = new List<Route>();
        static void Main(string[] args)
        { 
            // Specify the file path
            string filePath = "Input.txt";

            try
            {
                // Check if the file exists
                if (File.Exists(filePath))
                {
                    // Read each line from the file
                    foreach (string line in File.ReadLines(filePath))
                    {
                        // Split the line by commas
                        string[] parts = line.Split(',');

                        // Ensure there are three parts (Start, End, Distance)
                        if (parts.Length == 3)
                        {
                            var route = new Route
                            {
                                Start = parts[0],
                                End = parts[1],
                                Distance = int.Parse(parts[2])
                            };

                            // Add route to the list
                            routes.Add(route);
                        }
                        else
                        {
                            Console.WriteLine("Invalid line format: " + line);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File not found: " + filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            if (routes.Count > 0) 
            {            
                //run tests here
                //create service for:
                //1.Finding route distance
                //2.Compute number of trips from one town to another with condition
                //3. Finding shortest length
            }

        }
    }


    public class Route
    {
        public string Start { get; set; }
        public string End { get; set; }
        public int Distance { get; set; }
    }
}
