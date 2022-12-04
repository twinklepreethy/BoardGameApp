using BoardGameLibrary.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BoardGameApp
{
    class Program
    {
        private static async Task Main()
        {
            var sp = ConfigureDI();
            var game = sp.GetRequiredService<IStartGame>();
            await game.Start();
        }

        private static ServiceProvider ConfigureDI() =>
            new ServiceCollection()
                .AddSingleton<IStartGame, StartGame>()
                .AddSingleton<ICreateBoardService, CreateBoardService>()
                .AddSingleton<ICreateLandmineService, CreateLandmineService>()
                .AddSingleton<IGenerateRandomNumberService, GenerateRandomNumberService>()
                .AddSingleton<IPrintBoardService, PrintBoardService>()
                .AddSingleton<ISetCurrentPositionService, SetCurrentPositionService>()
                .AddSingleton<IGameOverCalculationService, GameOverCalculationService>()
                .AddSingleton<IGameWonCalculationService, GameWonCalculationService>()
                .BuildServiceProvider();
    }
}

