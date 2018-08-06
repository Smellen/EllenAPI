namespace EllenAPI.Controllers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using EllenAPI.Interfaces;

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
        /// Initializes a new instance of the <see cref="SteamController"/> class.
        /// </summary>
        /// <param name="domainService">The domain service.</param>
        public SteamController(ISteamDomainService domainService)
        {
            _steamDomainService = domainService ?? throw new ArgumentNullException("domainService");
        }

        /// <summary>
        /// Test steam key out.
        /// </summary>
        /// <returns>The status code from the Steam API request.</returns>
        public async Task<string> Get()
        {
            var client = new HttpClient();
            var gameCompletion = await _steamDomainService.GetAverageGameCompletion();

            return $"Steam game completion: {gameCompletion}";
        }
    }
}