using System;

namespace Mining.Application.Knapsack
{
    ///<Summary>
    /// 0/1 knapsack problem <see href="https://en.wikipedia.org/wiki/Knapsack_problem">HERE</see>
    ///</Summary>
    public class DefaultImpl : IKnapsack
    {

        static Lazy<DefaultImpl> instance =
                         new Lazy<DefaultImpl>(() => new DefaultImpl());

        public static DefaultImpl Instance => instance.Value;
        public double Calculate(int limit, int[] size, double[] values, int itemsCount)
        {
            double[,] K = new Double[itemsCount + 1, limit + 1];

            for (int i = 0; i <= itemsCount; ++i)
            {
                for (int w = 0; w <= limit; ++w)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (size[i - 1] <= w)
                        K[i, w] = Math.Max(values[i - 1] + K[i - 1, w - size[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[itemsCount, limit];
        }
    }
}