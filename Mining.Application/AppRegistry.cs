using Mining.Application.Knapsack;
using StructureMap;

namespace Mining.Application
{
    public class AppRegistry : Registry
    {
        public AppRegistry()
        {
            For<IKnapsack>().Use(DefaultImpl.Instance);
        }
    }
}