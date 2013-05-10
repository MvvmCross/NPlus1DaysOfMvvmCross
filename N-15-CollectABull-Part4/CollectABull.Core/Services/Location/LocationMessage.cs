using Cirrious.MvvmCross.Plugins.Messenger;

namespace CollectABull.Core.Services.Location
{
    public class LocationMessage
        : MvxMessage
    {
        public LocationMessage(object sender, double lat, double lng) 
            : base(sender)
        {
            Lat = lat;
            Lng = lng;
        }

        public double Lat { get; private set; }
        public double Lng { get; private set; }
    }
}