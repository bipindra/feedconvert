using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FeedConvert.Utils
{
    public class FeedFetcher :IDisposable
    {
        readonly HttpClient _client;
        public FeedFetcher()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetUrl(string url)
        {
            return await _client.GetStringAsync(url).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _client.Dispose();
        }

    }
}