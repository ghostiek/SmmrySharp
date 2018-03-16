using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace SmmrySharp
{
    public class SmmryDownloader
    {
        private static HttpClient Client = new HttpClient();

        private string Json { get; set; }

        public Smmry Smmry { get; private set; }

        public SmmryDownloader(SmmryParameters smmryParameters)
        {
            Json = GetJsonAsync(smmryParameters).GetAwaiter().GetResult();
            Smmry = JsonConvert.DeserializeObject<Smmry>(Json);

        }

        private async Task<string> GetJsonAsync(Dictionary<string, object> smmryParameters)
        {
            var url = $@"http://api.smmry.com/{smmryParameters}";

            using (var responsemessage = await Client.GetAsync(url))
            using (var content = responsemessage.Content)
            {
                return await content.ReadAsStringAsync();
            }
        }
    }
}
