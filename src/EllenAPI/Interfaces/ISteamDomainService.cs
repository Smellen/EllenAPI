namespace EllenAPI.Interfaces
{
    using System.Collections.Generic;
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

        /// <summary>
        /// Gets all owned games.
        /// </summary>
        /// <param name="steamUserID">The user identifier.</param>
        /// <returns>The collection of all owned games by a steam user.</returns>
        Task<ISteamUserOwnedGamesStats> GetAllOwnedGames(string steamUserID);

        /// <summary>
        /// Gets all owned game stats.
        /// </summary>
        /// <param name="steamUserID">The steam user identifier.</param>
        /// <returns>All games with achievement stats.</returns>
        /// <exception cref="ArgumentNullException">steamUserID</exception>
        /// <exception cref="ArgumentException">
        /// No owned games found.
        /// or
        /// No played games found.
        /// </exception>
        Task<IEnumerable<ISteamUserGameStats>> GetAllOwnedGameStats(string steamUserID);
    }
}
