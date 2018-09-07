namespace EllenAPI.Models
{
    using EllenAPI.Interfaces;
    using Newtonsoft.Json;

    /// <summary>
    /// The Steam game.
    /// </summary>
    /// <seealso cref="EllenAPI.Interfaces.ISteamGame" />
    public class SteamGame : ISteamGame
    {
        /// <summary>
        /// Gets or sets the identifier of a Steam game.
        /// </summary>
        /// <value>
        /// The Steam game identifier.
        /// </value>
        [JsonProperty("appid")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the playtime.
        /// </summary>
        /// <value>
        /// The playtime.
        /// </value>
        [JsonProperty("playtime_forever")]
        public int Playtime { get; set; }
    }
}