namespace CityInfo.API.Domain.Exceptions
{
    public class CityNotFoundException : Exception
    {
        public static CityNotFoundException ForId(int id)
        {
            return new($"City not found, for ID {id}.");
        }

        public CityNotFoundException(){}

        public CityNotFoundException(string message) : base(message){}

        public CityNotFoundException(string message, Exception inner) : base(message, inner){}
    }
}
