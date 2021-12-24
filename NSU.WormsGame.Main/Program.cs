using Microsoft.Extensions.Hosting;
using NSU.WormsGame.Services;
using NSU.WormsGame.Services.WormActionGeneratorService;
using Microsoft.Extensions.DependencyInjection;

namespace NSU.WormsGame.Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)

        {
            return Host.CreateDefaultBuilder(args)

                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<WormsSimulatorService>();
                    services.AddSingleton<IFoodGeneratorService, FoodGeneratorService>();
                    services.AddSingleton<IWormNamesGeneratorService, WormNamesGeneratorService>();
                    services.AddSingleton<IWormActionGeneratorService, MoveTorawdsFoodWormActionGeneratorService>();
                    services.AddSingleton<IGameStateWriterService, GameStateWriterService>();
                });

        }

    }
}

