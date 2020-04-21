namespace EllenAPI.Controllers
{
    using System.Diagnostics;
    using System.Reflection;
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
            var assembly = Assembly.GetExecutingAssembly();
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            return $"{fvi.ProductName} Version - {fvi.ProductVersion}";
        }
    }
}