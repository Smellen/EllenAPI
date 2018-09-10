namespace EllenAPI.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;
    using EllenAPI.Interfaces;
    using log4net;

    /// <summary>
    /// The steam controller.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class SteamController : ApiController
    {
        /// <summary>
        /// The steam domain service.
        /// </summary>
        private ISteamDomainService _steamDomainService;

        /// <summary>
        /// The log.
        /// </summary>
        private ILog _log;

        /// <summary>
        /// Initializes a new instance of the <see cref="SteamController"/> class.
        /// </summary>
        /// <param name="domainService">The domain service.</param>
        /// <param name="log">The log.</param>
        public SteamController(ISteamDomainService domainService, ILog log)
        {
            _steamDomainService = domainService ?? throw new ArgumentNullException("domainService");
            _log = log ?? throw new ArgumentNullException("log");
        }

        /// <summary>
        /// Gets the average completion rate for the steam user.
        /// </summary>
        /// <param name="steamID">The optional steam parameter.</param>
        /// <returns>The average game completion for the steam user.</returns>
        [HttpGet]
        public async Task<string> AverageGameCompletion(string steamID = "")
        {
            _log.Info($"Getting the average game completion.");
            var gameCompletion = await _steamDomainService.GetAverageGameCompletion();

            _log.Info($"Game Completion rate is : {gameCompletion}");

            return $"Steam game completion: {gameCompletion}%";
        }
    }
}