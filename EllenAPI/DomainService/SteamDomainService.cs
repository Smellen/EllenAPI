namespace EllenAPI.DomainService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EllenAPI.Interfaces;
    using EllenAPI.Models;
    using log4net;

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
        /// The domain service log.
        /// </summary>
        private ILog _log;

        /// <summary>
        /// Initializes a new instance of the <see cref="SteamDomainService"/> class.
        /// </summary>
        /// <param name="steamApi">The steam API.</param>
        /// <exception cref="ArgumentNullException">steamApi</exception>
        public SteamDomainService(IService steamApi, ILog log)
        {
            _steamAPIService = steamApi ?? throw new ArgumentNullException("steamApi");
            _log = log ?? throw new ArgumentNullException("log");
        }

        /// <summary>
        /// Gets the average game completion.
        /// </summary>
        /// <param name="steamUserID">The steam user identifier.</param>
        /// <returns>The average game completion.</returns>
        public async Task<double> GetAverageGameCompletion(string steamUserID)
        {
            if (string.IsNullOrWhiteSpace(steamUserID))
            {
                throw new ArgumentNullException("steamUserID");
            }

            double unlockedAchievements = 0;
            double totalAchievements = 0;
            var allOwnedGames = await _steamAPIService.GetGamesOwnedByAUser(steamUserID);

            if (allOwnedGames == null || allOwnedGames.Games == null || !allOwnedGames.Games.Any())
            {
                throw new ArgumentException("No owned games found.");
            }

            _log.Info($"All owned games count: {allOwnedGames.GameCount}");

            var playedGames = allOwnedGames.Games.Where(e => e.Playtime > 0);

            if (playedGames == null || !playedGames.Any())
            {
                throw new ArgumentException("No played games found.");
            }

            _log.Info($"All played games: {playedGames.Count()}");

            foreach (var game in playedGames)
            {
                _log.Info($"Game: {game.ID} & Playtime: {game.Playtime}");

                var gameStats = await _steamAPIService.GetAchievmentsForAGame(game.ID, steamUserID);
                if (gameStats != null && gameStats.Achievements != null && gameStats.Achievements.Any())
                {
                    _log.Info($"{gameStats.GameName}");
                    var unlocked = this.GetGameAchievementCount(gameStats.Achievements);
                    if (unlocked > 0)
                    {
                        _log.Info($"{game.ID}:{gameStats.GameName} - Achievements Unlocked: {unlocked}");
                        _log.Info($"{game.ID}:{gameStats.GameName} - Achievements Total   : {gameStats.Achievements.Count()}");
                        unlockedAchievements += unlocked;
                        totalAchievements += gameStats.Achievements.Count();
                    }
                }
                else
                {
                    _log.Info($"{game.ID} - No game stats");
                }
            }

            if (totalAchievements <= 0 && unlockedAchievements > 0)
            {
                _log.Error($"Divide by zero error with: {totalAchievements} / {unlockedAchievements}");
                throw new DivideByZeroException("The total count of achivements is 0 but there are unlocked achievements.");
            }

            _log.Info($"Total unlocked achivements: {unlockedAchievements}");
            _log.Info($"Total achivements: {totalAchievements}");

            return (unlockedAchievements / totalAchievements) * (100 / 1);
        }

        /// <summary>
        /// Gets the game achievement count.
        /// </summary>
        /// <param name="gameAchievements">The game achievements.</param>
        /// <returns>The compeletion rate for one game.</returns>
        public double GetGameAchievementCount(IEnumerable<SteamAchievement> gameAchievements)
        {
            if (gameAchievements == null || !gameAchievements.Any())
            {
                return 0;
            }

            return gameAchievements.Where(e => e.Unlocked).Count();
        }
    }
}