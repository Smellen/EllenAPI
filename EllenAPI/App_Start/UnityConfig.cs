namespace EllenAPI
{
    using EllenAPI.DomainService;
    using EllenAPI.Interfaces;
    using EllenAPI.Models;
    using EllenAPI.Services;
    using System.Configuration;
    using System.Net.Http;
    using System.Web.Http;
    using Unity;
    using Unity.Injection;
    using Unity.WebApi;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            var httpClient = new HttpClient();
            var steamKey = ConfigurationManager.AppSettings["SteamKey"];
            var steamUserID = ConfigurationManager.AppSettings["SteamUserID"];

            container.RegisterType<ISteamAchievement, SteamAchievement>();
            container.RegisterType<ISteamGame, SteamGame>();
            container.RegisterType<ISteamUserGameStats, SteamUserGameStats>();
            container.RegisterType<ISteamUserOwnedGamesStats, SteamUserOwnedGamesStats>();

            container.RegisterType<IService, SteamAPIService>(new InjectionConstructor(httpClient, steamKey, steamUserID));
            container.RegisterType<ISteamDomainService, SteamDomainService>(new InjectionConstructor(container.Resolve<IService>()));


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}