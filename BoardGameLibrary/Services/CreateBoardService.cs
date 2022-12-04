using BoardGameLibrary.Models;
using BoardGameLibrary.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameLibrary.Services
{
    public class CreateBoardService : ICreateBoardService
    {
        public Board CreateBoard(int rowSize, int colSize)
        {
            var board = new Board(rowSize, colSize);

            board.Grid = new Square[board.RowSize, board.ColSize];

            for (int i = 0; i < board.RowSize; i++)
            {
                for (int j = 0; j < board.ColSize; j++)
                {
                    board.Grid[i, j] = new Square(i, j);

                    if(i == BoardGameConstants.InitialRow && j == BoardGameConstants.InitialColumn)
                    {
                        board.Grid[i, j].isOccupied = true;
                        board.CurrentRow = i;
                        board.CurrentCol = j;
                    }
                }
            }

            return board;
        }
    }
}
