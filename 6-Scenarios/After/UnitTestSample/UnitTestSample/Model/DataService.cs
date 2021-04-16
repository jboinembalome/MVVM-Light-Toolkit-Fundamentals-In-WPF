using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnitTestSample.Model
{
    public class DataService : IDataService
    {
        public async Task<DataItem> GetData()
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync("https://localhost:44376/api/nugetintro");

            var myInstance = JsonConvert.DeserializeObject<DataItem>(json);
            return myInstance;
        }
    }
}