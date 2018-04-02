using System.Collections.Generic;
using Mining.Domain;

namespace Mining.Application.Services
{
    public interface IMiningService
    {
         double CalculateMaxFee(IEnumerable<Transaction> transactions, int maxBlockSize, double blockFee);
    }
}