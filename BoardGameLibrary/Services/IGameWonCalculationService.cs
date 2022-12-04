using BoardGameLibrary.Models;

namespace BoardGameLibrary.Services
{
    public interface IGameWonCalculationService
    {
        Task<bool> IsGameWon(int currentRow);
    }
}