using BoardGameLibrary.Models;

namespace BoardGameLibrary.Services
{
    public interface ICreateLandmineService
    {
        void CreateLandMine(Square[,] grid);
    }
}