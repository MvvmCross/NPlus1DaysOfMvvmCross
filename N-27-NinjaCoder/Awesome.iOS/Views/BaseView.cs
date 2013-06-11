// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the BaseView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Awesome.iOS.Views
{
    using Cirrious.MvvmCross.Touch.Views;

    using MonoTouch.Foundation;

    /// <summary>
    /// Defines the BaseView type.
    /// </summary>
    public abstract class BaseView : MvxViewController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseView" /> class.
        /// </summary>
        protected BaseView()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseView"/> class.
        /// </summary>
        /// <param name="nibName">Name of the nib.</param>
        /// <param name="bundle">The bundle.</param>
        protected BaseView(string nibName, NSBundle bundle)
            : base(nibName, bundle)
        {
        }
    }
}
