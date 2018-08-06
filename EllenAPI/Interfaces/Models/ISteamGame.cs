namespace EllenAPI.Interfaces
{
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
        int ID { get; set; }

        /// <summary>
        /// Gets or sets the playtime.
        /// </summary>
        /// <value>
        /// The playtime.
        /// </value>
        string Playtime { get; set; }
    }
}
