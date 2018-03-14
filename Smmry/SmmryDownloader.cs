using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Smmry
{
    public class SmmryDownloader
    {
        private static HttpClient Client = new HttpClient();
        
        public async Task<string> GetJsonAsync(Dictionary<string, object> smmryParameters)
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
