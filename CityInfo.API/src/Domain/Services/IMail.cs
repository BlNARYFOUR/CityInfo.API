namespace CityInfo.API.Domain.Services
{
    public interface IMail
    {
        public void Send(string subject, string message);
    }
}
