namespace EllenAPI.Models
{
    using System.Collections.Generic;
    using EllenAPI.Interfaces;
    using Newtonsoft.Json;

    /// <summary>
    /// The Steam user owned games statistics.
    /// </summary>
    /// <seealso cref="EllenAPI.Interfaces.ISteamUserOwnedGamesStats" />
    public class SteamUserOwnedGamesStats : ISteamUserOwnedGamesStats
    {
        /// <summary>
        /// Gets or sets the game count.
        /// </summary>
        /// <value>
        /// The game count.
        /// </value>
        [JsonProperty("game_count")]
        public int GameCount { get; set; }

        /// <summary>
        /// Gets or sets the list of Steam games owned by a user.
        /// </summary>
        /// <value>
        /// The list of owned Steam games.
        /// </value>
        [JsonProperty("games")]
        public IEnumerable<ISteamGame> Games { get; set; }
    }
}