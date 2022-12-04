using BoardGameLibrary.Models;
using BoardGameLibrary.Enums;

namespace BoardGameLibrary.Services
{
    public interface ISetCurrentPositionService
    {
        void SetCurrentSquare(Board board, MovesEnum currentMove);
    }
}