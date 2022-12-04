using BoardGameLibrary.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameLibrary.Services
{
    public class GenerateRandomNumberService : IGenerateRandomNumberService
    {
        public int GenerateRandomNumber(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }
    }
}
