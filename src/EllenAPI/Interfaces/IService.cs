﻿namespace EllenAPI.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// The service interface.
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Gets or sets the get games owned by a user.
        /// </summary>
        /// <value>
        /// The get games owned by a user.
        /// </value>
        Task<ISteamUserOwnedGamesStats> GetGamesOwnedByAUser(string steamUserID);

        /// <summary>
        /// Gets the achievements for a game.
        /// </summary>
        /// <param name="appID">The game identifier.</param>
        /// <param name="steamUserID">The steam user identifier.</param>
        /// <returns>A list of achievements for a game.</returns>
        Task<ISteamUserGameStats> GetAchievmentsForAGame(int appID, string steamUserID);
    }
}
