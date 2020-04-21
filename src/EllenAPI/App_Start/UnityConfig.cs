namespace EllenAPI
{
    using EllenAPI.Controllers;
    using EllenAPI.DomainService;
    using EllenAPI.Interfaces;
    using EllenAPI.Models;
    using EllenAPI.Services;
    using log4net;
    using System.Configuration;
    using System.Net.Http;
    using System.Web.Http;
    using Unity;
    using Unity.Injection;
    using Unity.WebApi;

    /// <summary>
    /// The unity config.
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// Registers the components.
        /// </summary>
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            var httpClient = new HttpClient();
            var steamKey = ConfigurationManager.AppSettings["SteamKey"];
            var log = LogManager.GetLogger(typeof(ILog));

            container.RegisterSingleton<ILog>();
            container.RegisterType<ISteamAchievement, SteamAchievement>();
            container.RegisterType<ISteamGame, SteamGame>();
            container.RegisterType<ISteamUserGameStats, SteamUserGameStats>();
            container.RegisterType<ISteamUserOwnedGamesStats, SteamUserOwnedGamesStats>();

            container.RegisterType<IService, SteamAPIService>(new InjectionConstructor(httpClient, steamKey));
            container.RegisterType<ISteamDomainService, SteamDomainService>(new InjectionConstructor(container.Resolve<IService>(), log));
            container.RegisterType<SteamController>(new InjectionConstructor(container.Resolve<ISteamDomainService>(), log));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}