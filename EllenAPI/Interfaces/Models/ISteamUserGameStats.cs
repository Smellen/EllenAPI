namespace EllenAPI.Interfaces
{
    using EllenAPI.Models;
    using System.Collections.Generic;

    /// <summary>
    /// The Steam user statistics interface.
    /// </summary>
    public interface ISteamUserGameStats
    {
        /// <summary>
        /// Gets or sets the Steam identifier.
        /// </summary>
        /// <value>
        /// The Steam identifier.
        /// </value>
        string SteamID { get; set; }

        /// <summary>
        /// Gets or sets the name of the game.
        /// </summary>
        /// <value>
        /// The name of the game.
        /// </value>
        string GameName { get; set; }

        /// <summary>
        /// Gets or sets the list of achievements.
        /// </summary>
        /// <value>
        /// The list of achievements.
        /// </value>
        IEnumerable<SteamAchievement> Achievements { get; set; }
    }
}
