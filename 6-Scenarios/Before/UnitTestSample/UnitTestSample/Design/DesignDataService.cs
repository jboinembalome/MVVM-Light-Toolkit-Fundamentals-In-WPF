using System.Threading.Tasks;
using UnitTestSample.Model;

namespace UnitTestSample.Design
{
    public class DesignDataService : IDataService
    {
        public Task<DataItem> GetData()
        {
            // Use this to create design time data

            var item = new DataItem()
            {
                Property1 = "Welcome to MVVM Light [design]",
                Property2 = 999
            };

            return Task.FromResult(item);
        }
    }
}