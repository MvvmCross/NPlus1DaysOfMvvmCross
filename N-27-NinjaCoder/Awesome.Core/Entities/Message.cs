// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the Message type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Awesome.Core.Entities
{
    using Cirrious.MvvmCross.Plugins.Messenger;

    /// <summary>
    ///    Defines the Message type.
    /// </summary>
    public class Message : MvxMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="sender">The sender.</param>
        public Message(object sender)
            : base(sender)
        {
        }
    }
}
