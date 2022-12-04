using BoardGameLibrary.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameLibrary.Models
{
    public class Board
    {
        public int RowSize { get; set; }
        public int ColSize { get; set; }
        public Square[,] Grid { get; set; }
        public int CurrentRow { get; set; }
        public int CurrentCol { get; set; }
        public int LandMineHits { get; set; }

        public Board(int rowSize, int colSize)
        {
            LandMineHits = 0;
            RowSize = rowSize;
            ColSize = colSize;
        }
    }
}
