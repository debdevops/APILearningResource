namespace MathAPI.Interface
{
    public interface IMathCalculations
    {
        Task<int> AddIntegerAsync(int x, int y);
        Task<int> SubtarctionAsync(int x, int y);
        Task<int> MultiplicationAsync(int x, int y);
        Task<int> DivideAsync(int x, int y);
    }
}
