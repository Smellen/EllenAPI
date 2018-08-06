namespace EllenAPI.DomainService
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EllenAPI.Interfaces;

    /// <summary>
    /// The Steam domain service.
    /// </summary>
    public class SteamDomainService : ISteamDomainService
    {
        /// <summary>
        /// The steam API service
        /// </summary>
        private IService _steamAPIService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SteamDomainService"/> class.
        /// </summary>
        /// <param name="steamApi">The steam API.</param>
        /// <exception cref="ArgumentNullException">steamApi</exception>
        public SteamDomainService(IService steamApi)
        {
            _steamAPIService = steamApi ?? throw new ArgumentNullException("steamApi");
        }

        /// <summary>
        /// Gets the average game completion.
        /// </summary>
        /// <returns>The average game completion.</returns>
        public async Task<double> GetAverageGameCompletion()
        {
            var getAllOwnedGames = await _steamAPIService.GetGamesOwnedByAUser();

            return getAllOwnedGames.GameCount;
        }
    }
}