namespace EllenAPI.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EllenAPI.DomainService;
    using EllenAPI.Interfaces;
    using EllenAPI.Models;
    using log4net;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// The Steam domain service unit test class.
    /// </summary>
    [TestClass]
    public class SteamDomainServiceUnitTests
    {

        private Mock<IService> _mockSteamApiService;
        private Mock<ILog> _mockLog;
        private IEnumerable<SteamGame> _listOfSteamGames;
        private SteamDomainService _mockSteamDomainSerice;

        /// <summary>
        /// The domain service test setup.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _mockSteamApiService = new Mock<IService>();
            _mockLog = new Mock<ILog>();
            _mockSteamDomainSerice = new Mock<SteamDomainService>(_mockSteamApiService.Object, _mockLog.Object).Object;
            _listOfSteamGames = new List<SteamGame>()
            {
                new SteamGame()
                {
                    ID = 24,
                    Playtime = 24
                },
                new SteamGame()
                {
                    ID = 42,
                    Playtime = 0
                }
            };
        }

        /// <summary>
        /// Test getting the owned games for a user when the users owns no games.
        /// </summary>
        /// <returns>A task.</returns>
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public async Task SteamDomainService_GetAverageGameCompletion_NoOwnedGamesFound()
        {
            _mockSteamApiService.Setup(e => e.GetGamesOwnedByAUser(It.IsAny<string>())).ReturnsAsync(new SteamUserOwnedGamesStats());
            await _mockSteamDomainSerice.GetAverageGameCompletion("ellen");
        }

        /// <summary>
        /// Test getting the owned games for a user when there are no played games found.
        /// </summary>
        /// <returns>A task.</returns>
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public async Task SteamDomainService_GetAverageGameCompletion_NoPlayedGamesFound()
        {
            _mockSteamApiService.Setup(e => e.GetGamesOwnedByAUser(It.IsAny<string>())).ReturnsAsync(new SteamUserOwnedGamesStats() { Games = new List<SteamGame>() { new SteamGame() { Playtime = 0 } } });
            await _mockSteamDomainSerice.GetAverageGameCompletion("ellen");
        }
    }
}
