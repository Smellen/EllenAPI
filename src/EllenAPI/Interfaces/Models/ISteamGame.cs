namespace EllenAPI.Interfaces
{
    using Newtonsoft.Json;

    /// <summary>
    /// The Steam game interface.
    /// </summary>
    public interface ISteamGame
    {
        /// <summary>
        /// Gets or sets the identifier of a Steam game.
        /// </summary>
        /// <value>
        /// The Steam game identifier.
        /// </value>
        [JsonProperty("appid")]
        int ID { get; set; }

        /// <summary>
        /// Gets or sets the playtime.
        /// </summary>
        /// <value>
        /// The playtime.
        /// </value>
        [JsonProperty("playtime_forever")]
        int Playtime { get; set; }
    }
}
