// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the ITypeResolverService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Awesome.Core.Services
{
    /// <summary>
    /// Defines the ITypeResolverService type.
    /// </summary>
    public interface ITypeResolverService
    {
        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns>An instance of TService.</returns>
        TService GetService<TService>() where TService : class;
    }
}
