using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSU.WormsGame.Simulation;
using NSU.WormsGame.Entities;
using Microsoft.Extensions.Hosting;
using NSU.WormsGame.Services;
using NSU.WormsGame.Services.WormActionGeneratorService;
using Microsoft.Extensions.DependencyInjection;

namespace NSU.WormsGame
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
                    services.AddScoped<IFoodGeneratorService, FoodGeneratorService>();
                    services.AddScoped<IWormNamesGeneratorService, WormNamesGeneratorService>();
                    services.AddScoped<IWormActionGeneratorService, MoveTorawdsFoodWormActionGeneratorService>();
                    services.AddScoped<IGameStateWriterService, GameStateWriterService>();
                });

        }

    }
}

