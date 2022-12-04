using AutoFixture;
using BoardGameLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameLibraryTests.ServicesTests
{
    public class CreateBoardServiceTests
    {
        private readonly ICreateBoardService _sut;

        public CreateBoardServiceTests()
        {
            _sut = new CreateBoardService();
        }

        [Fact]
        public void CreateBoard_InitialPosition_7_0_HappyPath()
        {
            var rowSize = 9;
            var colSize = 7;

            var result = _sut.CreateBoard(rowSize, colSize);

            Assert.NotNull(result);
            Assert.True(result.Grid[7, 0].isOccupied);
            Assert.Equal(7, result.CurrentRow);
            Assert.Equal(0, result.CurrentCol);
        }
    }
}
