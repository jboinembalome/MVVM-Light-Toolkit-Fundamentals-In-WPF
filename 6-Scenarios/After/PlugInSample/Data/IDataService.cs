using System.Threading.Tasks;

namespace PlugInSample.Contracts
{
    public interface IDataService
    {
        Task<TestObject> GetTestObject();
    }
}