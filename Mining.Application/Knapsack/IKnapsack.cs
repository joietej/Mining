namespace Mining.Application.Knapsack
{
    public interface IKnapsack
    {
         double Calculate(int limit, int[] size, double[] values, int itemsCount);
    }
}