using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Linq;


namespace SmmrySharp
{
    public class SmmryDownloader
    {
        private const string BaseUrl = "http://api.smmry.com/";

        private static HttpClient Client = new HttpClient();

        private string Json { get; set; }

        public Smmry Smmry { get; private set; }

        public SmmryDownloader(SmmryParameters smmryParameters)
        {
            Json = GetJsonAsync(smmryParameters).GetAwaiter().GetResult();
            Smmry = JsonConvert.DeserializeObject<Smmry>(Json);
            
            if(Smmry.GetType().GetProperties().All(x=> x.GetValue(Smmry) == null))
            {
                var error = JsonConvert.DeserializeObject<Error>(Json);
                throw new SmmryException($"{error.Code}: {error.Message}");
            }
        }

        private async Task<string> GetJsonAsync(Dictionary<string, object> smmryParameters)
        {
            var url = BaseUrl + smmryParameters;

            using (var responsemessage = await Client.GetAsync(url))
            using (var content = responsemessage.Content)
            {
                return await content.ReadAsStringAsync();
            }
        }

    }
}
