using BoardGameLibrary.Enums;
using BoardGameLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameLibraryTests.ServicesTests
{
    public class GameWonCalculationServiceTests
    {
        private readonly IGameWonCalculationService _sut;

        public GameWonCalculationServiceTests()
        {
            _sut = new GameWonCalculationService();
        }

        [Fact]
        public void IsGameWon_TopRow_Reached_True()
        {
            var currentRow = 0;

            var result = _sut.IsGameWon(currentRow);

            Assert.True(result.Result);
        }

        [Fact]
        public void IsGameWon_TopRow_Not_Reached_True()
        {
            var currentRow = 3;

            var result = _sut.IsGameWon(currentRow);

            Assert.False(result.Result);
        }
    }
}
