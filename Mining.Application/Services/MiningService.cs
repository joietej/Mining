using System.Collections.Generic;
using System.Linq;
using Mining.Application.Knapsack;
using Mining.Domain;

namespace Mining.Application.Services
{

    public class MiningService : IMiningService
    {
        private readonly IKnapsack knapsack;

        public MiningService(IKnapsack knapsack)
        {
            this.knapsack = knapsack;
        }

        public double CalculateMaxFee(IEnumerable<Transaction> transactions, int maxBlockSize, double blockFee)
        {
            var sizes = transactions.Select(x => x.Size).ToArray();
            var fees = transactions.Select(x => x.Fee).ToArray();

            var result = knapsack.Calculate(maxBlockSize,
                                                    sizes,
                                                    fees,
                                                    transactions.Count());



            return blockFee + result;

        }
    }

}