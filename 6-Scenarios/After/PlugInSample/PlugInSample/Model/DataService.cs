using Newtonsoft.Json;
using PlugInSample.Contracts;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlugInSample.Model
{
    public class DataService : IDataService
    {
        public async Task<TestObject> GetTestObject()
        {
            var client = new HttpClient();

            var json = await client.GetStringAsync(
                new Uri("https://localhost:44376/api/nugetintro"));

            var instance = JsonConvert.DeserializeObject<TestObject>(json);
            return instance;
        }
    }
}
