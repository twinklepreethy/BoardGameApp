using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameLibrary.Constants
{
    public static class BoardGameConstants
    {
        //Scalable on board size, initial position, max landmine hits, game winning row condition and landmine counts
        public const int Board_RowSize = 8; //8x8 board
        public const int Board_ColSize = 8; //8x8 board
        public const int InitialRow = Board_RowSize - 1;
        public const int InitialColumn = 0;
        public const int MaxLandmineHits = 2; //Max hit requirement -1
        public const int TopRow = 0;
        public const int LandmineTotal = 5;
    }
}
