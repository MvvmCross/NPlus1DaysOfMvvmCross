namespace CollectABull.Core.Services.Location
{
    public interface ILocationService
    {
        bool TryGetLatestLocation(out double lat, out double lng);
    }
}