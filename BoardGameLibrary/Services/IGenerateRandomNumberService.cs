namespace BoardGameLibrary.Services
{
    public interface IGenerateRandomNumberService
    {
        int GenerateRandomNumber(int min, int max);
    }
}