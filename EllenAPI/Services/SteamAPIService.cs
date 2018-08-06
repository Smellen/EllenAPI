namespace EllenAPI.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using EllenAPI.Interfaces;
    using EllenAPI.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The Steam API service.
    /// </summary>
    public class SteamAPIService : IService
    {
        /// <summary>
        /// The HTTP client
        /// </summary>
        private HttpClient _client;

        /// <summary>
        /// The steam key.
        /// </summary>
        private string _steamKey;

        /// <summary>
        /// The steam user identifier.
        /// </summary>
        private string _steamUserID;

        /// <summary>
        /// Initializes a new instance of the <see cref="SteamAPIService"/> class.
        /// </summary>
        public SteamAPIService(HttpClient client, string steamKey, string steamUserID)
        {
            if (string.IsNullOrWhiteSpace(steamKey))
            {
                throw new ArgumentNullException("steamKey");
            }

            if (string.IsNullOrWhiteSpace(steamUserID))
            {
                throw new ArgumentNullException("steamUserID");
            }

            _client = client;
            _steamKey = steamKey;
            _steamUserID = steamUserID;
        }

        /// <summary>
        /// Gets the achievements for a game.
        /// </summary>
        /// <param name="gameID">The game identifier.</param>
        /// <returns>
        /// A list of achievements for a game.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<ISteamUserGameStats> GetAchievmentsForAGame(int gameID)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets or sets the get games owned by a user.
        /// </summary>
        /// <returns>A list of owned steam games.</returns>
        /// <value>
        /// The get games owned by a user.
        /// </value>
        public async Task<ISteamUserOwnedGamesStats> GetGamesOwnedByAUser()
        {
            var ownedGamesUrl = $"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={_steamKey}&steamid={_steamUserID}&format=json";

            var response = await _client.GetAsync(ownedGamesUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var obj = JObject.Parse(jsonString);

                var data = obj["response"].ToObject<SteamUserOwnedGamesStats>();
                return data;
            }
            else
            {
                return null;
            }
        }
    }
}