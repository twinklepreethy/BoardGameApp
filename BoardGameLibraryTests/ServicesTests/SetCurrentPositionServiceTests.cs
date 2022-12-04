using AutoFixture;
using BoardGameLibrary.Enums;
using BoardGameLibrary.Models;
using BoardGameLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameLibraryTests.ServicesTests
{
    public class SetCurrentPositionServiceTests
    {
        private readonly ISetCurrentPositionService _sut;
        private readonly Fixture _fixture = new();

        public SetCurrentPositionServiceTests()
        {
            _sut = new SetCurrentPositionService();
        }

        [Fact]
        public void SetCurrentSquare_Move_Up_HappyPath()
        {
            Square[,] squareGrid = new Square[8, 8];
            squareGrid[3, 3] = new Square(3, 3);
            squareGrid[2, 3] = new Square(2, 3);
            squareGrid[2, 3].isLandmine = true;

            var move = MovesEnum.Up;
            var board = _fixture.Build<Board>()
                                .With(x => x.CurrentRow, 3)
                                .With(x => x.CurrentCol, 3)
                                .With(x => x.Grid, squareGrid)
                                .With(x => x.LandMineHits, 0).Create();

            _sut.SetCurrentSquare(board, move);

            Assert.Equal(2, board.CurrentRow);
            Assert.True(board.Grid[2, 3].isOccupied);
            Assert.Equal(1, board.LandMineHits);
        }

        [Fact]
        public void SetCurrentSquare_Move_Down_HappyPath()
        {
            Square[,] squareGrid = new Square[8, 8];
            squareGrid[3, 3] = new Square(3, 3);
            squareGrid[4, 3] = new Square(4, 3);

            var move = MovesEnum.Down;
            var board = _fixture.Build<Board>()
                                .With(x => x.CurrentRow, 3)
                                .With(x => x.CurrentCol, 3)
                                .With(x => x.Grid, squareGrid).Create();

            _sut.SetCurrentSquare(board, move);

            Assert.Equal(4, board.CurrentRow);
            Assert.True(board.Grid[4, 3].isOccupied);
        }

        [Fact]
        public void SetCurrentSquare_Move_Left_HappyPath()
        {
            Square[,] squareGrid = new Square[8, 8];
            squareGrid[3, 3] = new Square(3, 3);
            squareGrid[3, 2] = new Square(3, 2);

            var move = MovesEnum.Left;
            var board = _fixture.Build<Board>()
                                .With(x => x.CurrentRow, 3)
                                .With(x => x.CurrentCol, 3)
                                .With(x => x.Grid, squareGrid).Create();

            _sut.SetCurrentSquare(board, move);

            Assert.Equal(2, board.CurrentCol);
            Assert.True(board.Grid[3, 2].isOccupied);
        }

        [Fact]
        public void SetCurrentSquare_Move_Right_HappyPath()
        {
            Square[,] squareGrid = new Square[8, 8];
            squareGrid[3, 3] = new Square(3, 3);
            squareGrid[3, 4] = new Square(3, 4);

            var move = MovesEnum.Right;
            var board = _fixture.Build<Board>()
                                .With(x => x.CurrentRow, 3)
                                .With(x => x.CurrentCol, 3)
                                .With(x => x.Grid, squareGrid).Create();

            _sut.SetCurrentSquare(board, move);

            Assert.Equal(4, board.CurrentCol);
            Assert.True(board.Grid[3, 4].isOccupied);
        }

        [Fact]
        public void SetCurrentSquare_IndexOutOfRange_Exception()
        {
            var move = MovesEnum.Right;
            var board = _fixture.Build<Board>()
                                .With(x => x.CurrentRow, 50).Create();

            Assert.Throws<IndexOutOfRangeException>(() => _sut.SetCurrentSquare(board, move));
        }

        [Fact]
        public void SetCurrentSquare_NullReferenceException_Exception()
        {
            var move = MovesEnum.Right;
            Square[,] grid = null;
            var board = _fixture.Build<Board>()
                                .With(x => x.CurrentRow, 2)
                                .With(x => x.CurrentCol, 2)
                                .With(x => x.Grid, grid).Create();

            Assert.Throws<NullReferenceException>(() => _sut.SetCurrentSquare(board, move));
        }
    }
}
