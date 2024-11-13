namespace TrainRoute.Domain.Interfaces
{
    public interface IShortestRouteCalculator
    {
        int? FindShortestRoute(string start, string end);
    }
}
