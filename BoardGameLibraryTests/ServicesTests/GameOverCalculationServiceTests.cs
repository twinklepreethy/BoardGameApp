using AutoFixture;
using BoardGameLibrary.Enums;
using BoardGameLibrary.Models;
using BoardGameLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameLibraryTests.ServicesTests
{
    public class GameOverCalculationServiceTests
    {
        private readonly IGameOverCalculationService _sut;

        public GameOverCalculationServiceTests()
        {
            _sut = new GameOverCalculationService();
        }

        [Fact]
        public void IsGameOver_Move_Exit_True()
        {
            var landMineHits = 1;
            var move = MovesEnum.Exit;

            var result = _sut.IsGameOver(landMineHits, move);

            Assert.True(result.Result);
        }

        [Fact]
        public void IsGameOver_MoreThan_Max_LandMineHits_True()
        {
            var landMineHits = 3;
            var move = MovesEnum.Up;

            var result = _sut.IsGameOver(landMineHits, move);

            Assert.True(result.Result);
        }

        [Fact]
        public void IsGameOver_NoLandMineHits_False()
        {
            var landMineHits = 0;
            var move = MovesEnum.Down;

            var result = _sut.IsGameOver(landMineHits, move);

            Assert.False(result.Result);
        }
    }
}
