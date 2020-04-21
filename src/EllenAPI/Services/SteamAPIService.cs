namespace EllenAPI.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using EllenAPI.Interfaces;
    using EllenAPI.Models;
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
        /// Initializes a new instance of the <see cref="SteamAPIService"/> class.
        /// </summary>
        public SteamAPIService(HttpClient client, string steamKey)
        {
            if (string.IsNullOrWhiteSpace(steamKey))
            {
                throw new ArgumentNullException("steamKey");
            }

            _client = client;
            _steamKey = steamKey;
        }

        /// <summary>
        /// Gets the achievements for a game.
        /// </summary>
        /// <param name="appID">The game identifier.</param>
        /// <param name="steamUserID">The steam user identifier.</param>
        /// <returns>
        /// A list of achievements for a game.
        /// </returns>
        public async Task<ISteamUserGameStats> GetAchievmentsForAGame(int appID, string steamUserID)
        {
            var ownedGamesUrl = $" http://api.steampowered.com/ISteamUserStats/GetPlayerAchievements/v0001/?appid={appID}&key={_steamKey}&steamid={steamUserID}&format=json";

            var response = await _client.GetAsync(ownedGamesUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var obj = JObject.Parse(jsonString);

                var data = obj.ToObject<UserGameStatsResponse>();
                return data.PlayerStats;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets or sets the get games owned by a user.
        /// </summary>
        /// <returns>A list of owned steam games.</returns>
        /// <param name="steamUserID">The steam user identifier.</param>
        /// <value>
        /// The owned game statistics for a user.
        /// </value>
        public async Task<ISteamUserOwnedGamesStats> GetGamesOwnedByAUser(string steamUserID)
        {
            var ownedGamesUrl = $"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={_steamKey}&steamid={steamUserID}&format=json";

            var response = await _client.GetAsync(ownedGamesUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var obj = JObject.Parse(jsonString);

                var data = obj.ToObject<OwnedGamesResponse>();
                return data.Response;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>The response content.</returns>
        /// <exception cref="Exception">The exception throw from sending a request.</exception>
        private async Task<string> SendRequest(string url)
        {
            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception($"The request was not successful. {response.StatusCode} : {response.ReasonPhrase}");
            }
        }
    }
}