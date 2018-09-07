namespace EllenAPI.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// The owned games response.
    /// </summary>
    public class OwnedGamesResponse
    {
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>
        /// The response.
        /// </value>
        [JsonProperty("response")]
        public SteamUserOwnedGamesStats Response { get; set; }
    }
}