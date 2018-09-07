namespace EllenAPI.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user game statistics response.
    /// </summary>
    public class UserGameStatsResponse
    {
        /// <summary>
        /// Gets or sets the player stats.
        /// </summary>
        /// <value>
        /// The player stats.
        /// </value>
        [JsonProperty("playerstats")]
        public SteamUserGameStats PlayerStats { get; set; }
    }
}