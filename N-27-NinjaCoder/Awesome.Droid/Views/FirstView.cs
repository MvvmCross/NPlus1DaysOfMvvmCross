// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the FirstView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Awesome.Droid.Views
{
    using Android.App;
    using Android.OS;

    /// <summary>
    /// Defines the FirstView type.
    /// </summary>
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : BaseView
    {
        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="bundle">The bundle.</param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.FirstView);
        }
    }
}