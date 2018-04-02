using System.Data;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mining.Tests.ApplicationTests
{
    [TestClass]
    public class MiningServiceShould
    {
        [DataTestMethod]
        [DataRow(500000,13.4376,12.5)]
        public void ReturnExpectedResultGivenTransactionsAndLimit(int maxBlockSize,
                                                                  double expectedResult,
                                                                  double blockFee)
        {
            var importer = new Mining.Infrastructure.TransactionImporter();
            var data =    importer.Import(@"../../../../input.csv");
            var impl = Mining.Application.Knapsack.DefaultImpl.Instance;
            var service = new Mining.Application.Services.MiningService(impl);
            var result =  service.CalculateMaxFee(data, maxBlockSize, blockFee);
           
            Assert.AreEqual(expectedResult,result);
        }
    }
}
