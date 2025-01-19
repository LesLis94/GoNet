using GoNet.BL;
using GoNet.BusinessLogic;
using GoNet.BusinessLogic.Services;
using GoNet.BusinessLogic.Services.Abstract;
using GoNet.Core.Abstract;
using GoNet.DataAccess;

namespace GoNet.Extensions
{
    public static class ExtensionProgram
    {
        public static void BuilderServicesServices(this IServiceCollection services) {
            // Add services to the container.net
            // регаем зависимости
            services.AddScoped<IRoulette, Ruletka>();
            services.AddScoped<IPlayersService, PlayersService>();
            services.AddScoped<IRepositoryPlayer, RepositoryPlayer>();
            services.AddScoped<IThingsPlayersService, ThingsPlayersService>();
            services.AddScoped<IRepositoryThingPlayer, RepositoryThingPlayer>();
            services.AddScoped<IBank, Bank>();
        }
    }
}
