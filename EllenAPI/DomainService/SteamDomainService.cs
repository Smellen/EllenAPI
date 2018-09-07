namespace EllenAPI.DomainService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EllenAPI.Interfaces;
    using EllenAPI.Models;

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
            double unlockedAchievements = 0;
            double totalAchievements = 0;
            var allOwnedGames = await _steamAPIService.GetGamesOwnedByAUser();
            var playedGames = allOwnedGames.Games.Where(e => e.Playtime > 0);

            foreach (var game in playedGames)
            {
                var gameStats = await _steamAPIService.GetAchievmentsForAGame(game.ID);
                if (gameStats != null && gameStats.Achievements != null && gameStats.Achievements.Any())
                {
                    var unlocked = this.GetGameAchievementCount(gameStats.Achievements);
                    if (unlocked > 0)
                    {
                        unlockedAchievements += unlocked;
                        totalAchievements += gameStats.Achievements.Count();
                    }
                }
            }

            if (totalAchievements <= 0)
            {
                throw new DivideByZeroException("The total count of achivements is null!");
            }

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