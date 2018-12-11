using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Labb2OOAD.Models
{
    public class ApiService
    {
        public ApiService()
        {
        }

        public static HttpClient client = new HttpClient();

        public static async Task<CityDtO[]> GetProductAsync(string path)
        {
            //JObject jObject = new JObject();
            CityDtO[] city = null;
            HttpResponseMessage response = await client.GetAsync(path);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var test = JObject.Parse(content);
                var result = test["result"].ToString();
                city = JsonConvert.DeserializeObject<CityDtO[]>(result);
            }
            return city;
        }

    }
}

