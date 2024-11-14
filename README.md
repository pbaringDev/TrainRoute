# TrainRoute
This is .Net console application that finds train routes between towns given an input file. In the 
input file, every line represents a direct link from one town to another and its length (distance).

A Command Pattern is used as a design pattern to accomodate different request or command, and call designated object for each request. This also allows for easy extension or modification of commands. Below are the possible 5 commands.

* a - Find the distance of a route
* b - Get the number of trips with a maximum number of stops
* c - Get the number of trips with an exact number of stops
* d - Find the shortest route between two towns
* e - Get the number of trips with a distance limit

An "Invalid Command" argument exception will be thrown if the application doesn't recognized the user's command input.

