using BoardGameLibrary.Models;
using BoardGameLibrary.Constants;
using BoardGameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameLibrary.Services
{
    public class GameOverCalculationService : IGameOverCalculationService
    {
        public async Task<bool> IsGameOver(int landmineHits, MovesEnum move)
        {
            return move == MovesEnum.Exit || landmineHits > BoardGameConstants.MaxLandmineHits;
        }
    }
}
