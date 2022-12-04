using AutoFixture;
using BoardGameLibrary.Models;
using BoardGameLibrary.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameLibraryTests.ServicesTests
{
    public class CreateLandmineServiceTests
    {
        private readonly Mock<IGenerateRandomNumberService> _mockGenerateRandomNumberService = new();
        private readonly ICreateLandmineService _sut;
        private readonly Fixture _fixture = new();

        public CreateLandmineServiceTests()
        {
            _sut = new CreateLandmineService(_mockGenerateRandomNumberService.Object);
        }

        [Fact]
        public void CreateLandMine_Landmine_In_3_3_HappyPath()
        {
            Square[,] squareGrid = new Square[8, 8];
            squareGrid[3, 3] = new Square(3, 3);

            _mockGenerateRandomNumberService.Setup(x => x.GenerateRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(3);
                                
            _sut.CreateLandMine(squareGrid);

            Assert.NotNull(squareGrid[3, 3]);
            Assert.True(squareGrid[3, 3].isLandmine);
        }

        [Fact]
        public void CreateLandMine_Landmine_In_InitialPos_Change_RowAbove()
        {
            Square[,] squareGrid = new Square[8, 8];
            squareGrid[6, 0] = new Square(6, 0);

            _mockGenerateRandomNumberService.Setup(x => x.GenerateRandomNumber(1, 7)).Returns(7);
            _mockGenerateRandomNumberService.Setup(x => x.GenerateRandomNumber(0, 7)).Returns(0);

            _sut.CreateLandMine(squareGrid);

            Assert.NotNull(squareGrid[6, 0]);
            Assert.True(squareGrid[6, 0].isLandmine);
        }
    }
}
