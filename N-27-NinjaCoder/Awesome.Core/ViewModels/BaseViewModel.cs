// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the BaseViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Awesome.Core.ViewModels
{
    using Cirrious.CrossCore;
    using Cirrious.MvvmCross.ViewModels;
    using Awesome.Core.Services;

    /// <summary>
    ///    Defines the BaseViewModel type.
    /// </summary>
    public abstract class BaseViewModel : MvxViewModel
    {
        /// <summary>
        /// The type resolver service.
        /// </summary>
        private readonly ITypeResolverService typeResolverService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        protected BaseViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        /// <param name="typeResolverService">The type resolver service.</param>
        protected BaseViewModel(ITypeResolverService typeResolverService)
        {
            this.typeResolverService = typeResolverService;
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns>An instance of the service.</returns>
        public TService GetService<TService>() where TService : class
        {
            return this.typeResolverService == null
                       ? Mvx.Resolve<TService>()
                       : this.typeResolverService.GetService<TService>();
        }
    }
}
