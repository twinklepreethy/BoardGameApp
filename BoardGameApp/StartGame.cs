using BoardGameLibrary.Models;
using BoardGameLibrary.Constants;
using BoardGameLibrary.Enums;
using BoardGameLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameApp
{
    public class StartGame : IStartGame
    {
        private readonly ICreateBoardService _createBoardService;
        private readonly IPrintBoardService _printBoardService;
        private readonly ISetCurrentPositionService _setCurrentSquareService;
        private readonly IGameOverCalculationService _gameOverCalculationService;
        private readonly IGameWonCalculationService _gameWonCalculationService;
        private readonly ICreateLandmineService _createLandmineService;

        public StartGame(ICreateBoardService createBoardService, IPrintBoardService printBoardService, ISetCurrentPositionService setCurrentSquareService, IGameOverCalculationService gameOverCalculationService, IGameWonCalculationService gameWonCalculationService,
            ICreateLandmineService createLandmineService)
        {
            _createBoardService = createBoardService;
            _printBoardService = printBoardService;
            _setCurrentSquareService = setCurrentSquareService;
            _gameOverCalculationService = gameOverCalculationService;
            _gameWonCalculationService = gameWonCalculationService;
            _createLandmineService = createLandmineService;
        }

        //Game Setup
        public async Task Start()
        {
            try
            {
                //Creating an empty board with the intial user position
                var board = _createBoardService.CreateBoard(BoardGameConstants.Board_RowSize, BoardGameConstants.Board_ColSize);

                //Generating random land mines
                _createLandmineService.CreateLandMine(board.Grid);

                bool isGameRunning;
                do
                {
                    _printBoardService.PrintBoard(board);
                    Console.WriteLine("Make a move (U - up, D - down, L - Left, R - Right, E - Exit) : ");
                    var currentMove = Console.ReadLine().ToUpper();
                    var move = GetMove(currentMove);

                    _setCurrentSquareService.SetCurrentSquare(board, move);

                    var isGameOver = await _gameOverCalculationService.IsGameOver(board.LandMineHits, move);
                    var isGameWon = await _gameWonCalculationService.IsGameWon(board.CurrentRow);

                    isGameRunning = !isGameWon && !isGameOver;

                    if(!isGameRunning) _printBoardService.PrintBoard(board);

                    if (isGameOver) Console.WriteLine("Game Lost...");
                    if (isGameWon) Console.WriteLine("Game Won...");

                } while (isGameRunning);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private MovesEnum GetMove(string move)
        {
            switch (move)
            {
                case "U": return MovesEnum.Up;
                case "D": return MovesEnum.Down;
                case "L": return MovesEnum.Left;
                case "R": return MovesEnum.Right;
                case "E": return MovesEnum.Exit;
                default:
                    return MovesEnum.Exit;
            }
        }
    }
}
