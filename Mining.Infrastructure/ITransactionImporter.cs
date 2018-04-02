using System.Collections.Generic;
using System.Threading.Tasks;
using Mining.Domain;

namespace Mining.Infrastructure
{
    public interface ITransactionImporter
    {
        IEnumerable<Transaction> Import(string filePath , string delimiter = "\t");
        //Task<IEnumerable<Transaction>> ImportAsync(string filePath , string delimiter = "\t");
         
    }
}