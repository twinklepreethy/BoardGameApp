using BoardGameLibrary.Models;
using BoardGameLibrary.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameLibrary.Services
{
    public class PrintBoardService : IPrintBoardService
    {
        public void PrintBoard(Board board)
        {
            Console.WriteLine("TO WIN REACH THE TOP !");
            Console.WriteLine("**********************************");

            for (int row = 0; row < board.RowSize; row++)
            {
                for (int i = 0; i < board.ColSize; i++)
                {
                    Console.Write("+---");
                }
                Console.Write("+");
                Console.WriteLine();
                Console.Write("|");

                for (int col = 0; col < board.ColSize; col++)
                {
                    var square = board.Grid[row, col];

                    if (square.isOccupied)
                    {
                        Console.Write(" X ");
                    }
                    else if (square.isLandmine)
                    {
                        Console.Write(" O ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                    Console.Write("|");
                }

                Console.WriteLine();
            }

            for (int j = 0; j < board.ColSize; j++)
            {
                Console.Write("+---");
            }
            Console.Write("+");
            Console.WriteLine();

            Console.WriteLine("**********************************");
            Console.WriteLine("Current location on the board: {0} , {1}", board.CurrentRow, board.CurrentCol);
            Console.WriteLine("Current No. of Landmines hit (Max {0} hits allowed): {1}", BoardGameConstants.MaxLandmineHits, board.LandMineHits);
            Console.WriteLine("**********************************");
        }
    }
}
