namespace EllenAPI.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// The Steam domain service interface.
    /// </summary>
    public interface ISteamDomainService
    {
        /// <summary>
        /// Gets or sets the get average game completion.
        /// </summary>
        /// <param name="steamUserID">The steam user identifier.</param>
        /// <value>
        /// The get average game completion.
        /// </value>
        Task<double> GetAverageGameCompletion(string steamUserID);   
    }
}
