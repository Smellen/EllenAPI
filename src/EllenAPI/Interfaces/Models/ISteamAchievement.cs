namespace EllenAPI.Interfaces
{
    public interface ISteamAchievement
    {
        /// <summary>
        /// Gets or sets the name of the achievement.
        /// </summary>
        /// <value>
        /// The achivement name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ISteamAchievement"/> is unlocked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if unlocked; otherwise, <c>false</c>.
        /// </value>
        bool Unlocked { get; set; }

        /// <summary>
        /// Gets or sets the unlock time.
        /// </summary>
        /// <value>
        /// The unlock time.
        /// </value>
        string UnlockTime { get; set; }
    }
}
