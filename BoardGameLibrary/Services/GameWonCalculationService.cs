using BoardGameLibrary.Models;
using BoardGameLibrary.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameLibrary.Services
{
    public class GameWonCalculationService : IGameWonCalculationService
    {
        public async Task<bool> IsGameWon(int currentRow)
        {
            return currentRow == BoardGameConstants.TopRow;
        }
    }
}
