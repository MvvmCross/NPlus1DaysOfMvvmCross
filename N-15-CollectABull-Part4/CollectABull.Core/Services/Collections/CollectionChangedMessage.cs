using Cirrious.MvvmCross.Plugins.Messenger;

namespace CollectABull.Core.Services.Collections
{
    public class CollectionChangedMessage
        : MvxMessage
    {
        public CollectionChangedMessage(object sender) : base(sender)
        {
        }
    }
}