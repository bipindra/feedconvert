using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using FeedConvert.Models;
using FeedConvert.Utils;

namespace FeedConvert.Controllers
{
    [Route("api/feeds")]
    [EnableCors("*","*","*")]
    public class FeedsController : ApiController
    {
        public async Task<Feed> Get(string url)
        {
            return await GetFeed(url);
        }

        public async Task<Feed> Post([FromBody] dynamic urlBody)
        {
            string url = urlBody.url;
           
            return await GetFeed(url);
        }

        private async Task<Feed> GetFeed(string url)
        {
            Feed model;
            using (var ff = new FeedFetcher())
            {
                if (url != null)
                {
                    var data = await ff.GetUrl(url);
                    model = FeedConvertUtils.RssToFeedModel(data);
                }
                else
                {
                    model = new Feed();
                }
            }
            return model;
        }
    }
}
