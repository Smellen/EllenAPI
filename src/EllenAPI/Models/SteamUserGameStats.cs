namespace EllenAPI.Models
{
    using System.Collections.Generic;
    using EllenAPI.Interfaces;

    /// <summary>
    /// The Steam user game statistics.
    /// </summary>
    public class SteamUserGameStats : ISteamUserGameStats
    {
        /// <summary>
        /// Gets or sets the Steam identifier.
        /// </summary>
        /// <value>
        /// The Steam identifier.
        /// </value>
        public string SteamID { get; set; }

        /// <summary>
        /// Gets or sets the name of the game.
        /// </summary>
        /// <value>
        /// The name of the game.
        /// </value>
        public string GameName { get; set; }

        /// <summary>
        /// Gets or sets the list of achievements.
        /// </summary>
        /// <value>
        /// The list of achievements.
        /// </value>
        public IEnumerable<SteamAchievement> Achievements { get; set; }
    }
}