using CityInfo.API.Domain.Models;
namespace CityInfo.API.Domain.Requests.PointsOfInterest
{
    public class GetPointsOfInterestQuery : IRequest<GetPointsOfInterestQueryResult>
    {
        public int CityId { get; set; }
    }
}
