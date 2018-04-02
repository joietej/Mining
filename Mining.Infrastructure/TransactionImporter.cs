using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Mining.Domain;

namespace Mining.Infrastructure
{
    public class TransactionImporter : ITransactionImporter
    {
        // public async Task<IEnumerable<Transaction>> ImportAsync(string filePath , string delimiter = "\t")
        // {

        //     var data = await File.ReadAllTextAsync(filePath);
        //     var config = new Configuration
        //     {
        //         Delimiter = delimiter
        //     };

        //     using (var textReader = new StringReader(data))
        //     {
        //         return new CsvReader(textReader, config)
        //                     .GetRecords<Transaction>()
        //                     .ToList();
        //     }

        // }

         public IEnumerable<Transaction> Import(string filePath , string delimiter = "\t")
        {

            var data = File.ReadAllText(filePath);
            var config = new Configuration
            {
                Delimiter = delimiter
            };

            using (var textReader = new StringReader(data))
            {
                return new CsvReader(textReader, config)
                            .GetRecords<Transaction>()
                            .ToList();
            }

        }
        
    }
}