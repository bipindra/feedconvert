using System.Threading.Tasks;
using System.Web.Http;
using FeedConvert.Models;
using FeedConvert.Utils;

namespace FeedConvert.Controllers
{
    [Route("api/feeds")]
    public class FeedsController : ApiController
    {
        public async Task<Feed> Get(string url)
        {
            Feed model;
            using (var ff = new FeedFetcher())
            {
                var data = await ff.GetUrl(url);
                model = FeedConvertUtils.RssToFeedModel(data);
            }
            return model;
        }
    }
}
