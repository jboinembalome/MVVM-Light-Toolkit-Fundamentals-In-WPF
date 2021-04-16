using System.Threading.Tasks;

namespace UnitTestSample.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}