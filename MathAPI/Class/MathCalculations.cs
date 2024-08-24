using MathAPI.Interface;

namespace MathAPI.Class
{
    public class MathCalculations : IMathCalculations
    {
        public Task<int> AddIntegerAsync(int x, int y)
        {
            return Task.FromResult(x + y);
        }

        public Task<int> SubtarctionAsync(int x, int y)
        {
            return Task.FromResult(x - y);
        }

        public Task<int> MultiplicationAsync(int x, int y)
        {
            return Task.FromResult(x * y);
        }

        public Task<int> DivideAsync(int x, int y)
        {
            return Task.FromResult(x / y);
        }
    }
}
