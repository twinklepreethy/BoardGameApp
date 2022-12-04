using BoardGameLibrary.Models;
using BoardGameLibrary.Enums;

namespace BoardGameLibrary.Services
{
    public interface IGameOverCalculationService
    {
        Task<bool> IsGameOver(int landmineHits, MovesEnum move);
    }
}