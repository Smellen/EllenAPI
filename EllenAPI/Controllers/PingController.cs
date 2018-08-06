namespace EllenAPI.Controllers
{
    using System.Web.Http;

    /// <summary>
    /// The ping controller.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class PingController : ApiController
    {
        /// <summary>
        /// Gets the version of the API.
        /// </summary>
        /// <returns>The API version.</returns>
        public string Get()
        {
            // TODO: Read from config file.
            return "EllenAPI Version 0.1";
        }
    }
}