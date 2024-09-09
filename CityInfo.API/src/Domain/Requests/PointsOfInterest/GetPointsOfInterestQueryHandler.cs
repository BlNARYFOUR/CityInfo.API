namespace CityInfo.API.Domain.Requests.PointsOfInterest
{
    public class GetPointsOfInterestQueryHandler : IRequestHandler<GetPointsOfInterestQuery, GetPointsOfInterestQueryResult>
    {
        Task<GetPointsOfInterestQueryResult> IRequestHandler<GetPointsOfInterestQuery, GetPointsOfInterestQueryResult>.HandleAsync(GetPointsOfInterestQuery request, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
