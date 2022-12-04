using BoardGameLibrary.Models;
using BoardGameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGameLibrary.Constants;

namespace BoardGameLibrary.Services
{
    public class SetCurrentPositionService : ISetCurrentPositionService
    {
        public void SetCurrentSquare(Board board, MovesEnum currentMove)
        {
            var newRow = BoardGameConstants.InitialRow;
            var newCol = BoardGameConstants.InitialColumn;
            board.Grid[board.CurrentRow, board.CurrentCol].isOccupied = false;
            switch (currentMove)
            {
                case MovesEnum.Up:
                    newRow = board.CurrentRow - 1;
                    newCol = board.CurrentCol;
                    break;
                case MovesEnum.Down:
                    newRow = board.CurrentRow + 1;
                    newCol = board.CurrentCol;
                    break;
                case MovesEnum.Left:
                    newRow = board.CurrentRow;
                    newCol = board.CurrentCol - 1;
                    break;
                case MovesEnum.Right:
                    newRow = board.CurrentRow;
                    newCol = board.CurrentCol + 1;
                    break;
                default:
                    break;
            }
            board.CurrentRow = newRow;
            board.CurrentCol = newCol;

            board.Grid[newRow, newCol].isOccupied = true;
            board.LandMineHits = board.Grid[newRow, newCol].isLandmine ? board.LandMineHits + 1 : board.LandMineHits;
        }
    }
}
