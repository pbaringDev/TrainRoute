using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TrainRoute.Model;

namespace TrainRoute.Service
{
    public class FileService
    {
        public Dictionary<string, List<Route>> LoadRoutesFromFile(string filePath)
        {
            var routesMap = new Dictionary<string, List<Route>>();
            try
            {
                if (File.Exists(filePath))
                {
                    foreach (string line in File.ReadLines(filePath))
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 3)
                        {
                            string start = parts[0];
                            string end = parts[1];
                            int distance = int.Parse(parts[2]);

                            var route = new Route { Start = start, End = end, Distance = distance };

                            if (!routesMap.ContainsKey(start))
                            {
                                routesMap[start] = new List<Route>();
                            }

                            routesMap[start].Add(route);
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
            
            return routesMap;
        }
    }
}
