using AutoFixture;
using BoardGameApp;
using BoardGameLibrary.Enums;
using BoardGameLibrary.Models;
using BoardGameLibrary.Services;
using Moq;

namespace BoardGameAppTests
{
    public class StartGameTests
    {
        private readonly Mock<ICreateBoardService> _mockCreateBoardService = new();
        private readonly Mock<IPrintBoardService> _mockPrintBoardService = new();
        private readonly Mock<ISetCurrentPositionService> _mockSetCurrentSquareService = new();
        private readonly Mock<IGameOverCalculationService> _mockGameOverCalculationService = new();
        private readonly Mock<IGameWonCalculationService> _mockGameWonCalculationService = new();
        private readonly Mock<ICreateLandmineService> _mockCreateLandmineService = new();

        private readonly Fixture _fixture = new();
        private readonly PrivateObject _privateObject;
        private readonly IStartGame _sut;

        public StartGameTests()
        {
            _sut = new StartGame(_mockCreateBoardService.Object, _mockPrintBoardService.Object, _mockSetCurrentSquareService.Object, _mockGameOverCalculationService.Object, _mockGameWonCalculationService.Object, _mockCreateLandmineService.Object);

            _privateObject = new PrivateObject(_sut);
        }

        [Fact]
        public void Start_HappyPath()
        {
            var grid = new Square[8, 8];
            grid[3, 2] = new Square(3, 2);
            grid[7, 0] = new Square(7, 0) { isOccupied = true };

            var board = _fixture.Build<Board>()
                                .With(x => x.CurrentRow, 7)
                                .With(x => x.CurrentCol, 0)
                                .With(x => x.RowSize, 8)
                                .With(x => x.ColSize, 8)
                                .With(x => x.Grid, grid).Create();

            _mockCreateBoardService.Setup(x => x.CreateBoard(It.IsAny<int>(), It.IsAny<int>())).Returns(board);
            _mockCreateLandmineService.Setup(x => x.CreateLandMine(It.IsAny<Board>())).Callback((Board b) =>
            {
                board.Grid[3, 2].isLandmine = true;
            });

            _sut.Start();

        }

        [Fact]
        public void GetMove_In_U_D_L_R_E_ReturnAssignedEnum()
        {
            object[] parameters = new object[1];
            parameters[0] = "U";

            var result = (MovesEnum)_privateObject.Invoke("GetMove", parameters);

            Assert.Equal(MovesEnum.Up, result);
        }

        [Fact]
        public void GetMove_NotIn_U_D_L_R_E_ReturnExit()
        {
            object[] parameters = new object[1];
            parameters[0] = "tt";

            var result = (MovesEnum)_privateObject.Invoke("GetMove", parameters);

            Assert.Equal(MovesEnum.Exit, result);
        }
    }
}