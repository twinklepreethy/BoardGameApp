using BoardGameLibrary.Models;
using BoardGameLibrary.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameLibrary.Services
{
    public class CreateLandmineService : ICreateLandmineService
    {
        private readonly IGenerateRandomNumberService _generateRandomNumberService;
        public CreateLandmineService(IGenerateRandomNumberService generateRandomNumberService)
        {
            _generateRandomNumberService = generateRandomNumberService;
        }

        public void CreateLandMine(Square[,] grid)
        {
            for (int i = 0; i < BoardGameConstants.LandmineTotal; i++)
            {              
                var row = _generateRandomNumberService.GenerateRandomNumber(BoardGameConstants.TopRow + 1, BoardGameConstants.Board_RowSize - 1);
                var col = _generateRandomNumberService.GenerateRandomNumber(BoardGameConstants.InitialColumn, BoardGameConstants.Board_ColSize - 1);

                row = row == BoardGameConstants.InitialRow && col == BoardGameConstants.InitialColumn ? row - 1 : row;

                grid[row, col].isLandmine = true;
            }
        }
    }
}
