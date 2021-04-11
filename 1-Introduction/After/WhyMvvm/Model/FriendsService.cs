using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WhyMvvm.Model
{
    public class FriendsService : IFriendsService
    {
        private const string UrlBase = "https://localhost:44376/api/friends/";

        public async Task<IEnumerable<Friend>> Refresh()
        {
            var client = new HttpClient();
            
            var uri = new Uri(UrlBase);
            
            var json = await client.GetStringAsync(uri);

            var result = JsonConvert.DeserializeObject<IEnumerable<Friend>>(json);
            return result;
        }

        public async Task<Friend> Save(Friend updatedFriend)
        {
            var client = new HttpClient();

            var uri = new Uri(UrlBase + updatedFriend.Id);

            var json = JsonConvert.SerializeObject(updatedFriend);

            try
            {
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PutAsync(uri, content);

                var result = await response.Content.ReadAsStringAsync();

                var resultToObject = JsonConvert.DeserializeObject<Friend>(result);

                return resultToObject;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
