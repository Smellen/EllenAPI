﻿namespace EllenAPI.Models
{
    using EllenAPI.Interfaces;
    using Newtonsoft.Json;

    /// <summary>
    /// The Steam achievement.
    /// </summary>
    public class SteamAchievement : ISteamAchievement
    {
        /// <summary>
        /// Gets or sets the name of the achievement.
        /// </summary>
        /// <value>
        /// The achivement name.
        /// </value>
        [JsonProperty("apiname")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ISteamAchievement" /> is unlocked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if unlocked; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("achieved")]
        public bool Unlocked { get; set; }

        /// <summary>
        /// Gets or sets the unlock time.
        /// </summary>
        /// <value>
        /// The unlock time.
        /// </value>
        [JsonProperty("unlocktime")]
        public string UnlockTime { get; set; }
    }
}