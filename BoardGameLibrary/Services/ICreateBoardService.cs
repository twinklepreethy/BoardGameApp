using BoardGameLibrary.Models;

namespace BoardGameLibrary.Services
{
    public interface ICreateBoardService
    {
        Board CreateBoard(int rowSize, int colSize);
    }
}