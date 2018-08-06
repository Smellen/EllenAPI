namespace EllenAPI.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The Steam user owned game statistics.
    /// </summary>
    public interface ISteamUserOwnedGamesStats
    {
        /// <summary>
        /// Gets or sets the game count.
        /// </summary>
        /// <value>
        /// The game count.
        /// </value>
        int GameCount { get; set; }

        /// <summary>
        /// Gets or sets the list of Steam games owned by a user.
        /// </summary>
        /// <value>
        /// The list of owned Steam games.
        /// </value>
        IEnumerable<ISteamGame> Games { get; set; }
    }
}
