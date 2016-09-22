using FeedConvert.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FeedConvert.Tests.Utils
{
    [TestClass]
    public class TestFeedConvertUtils
    {
        [TestMethod]
        public void TestRssFeed()
        {
            var xml = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?><rss version=\"2.0\"><channel><title>W3Schools Home Page</title><link>http://www.w3schools.com</link><description>Free web building tutorials</description><item><title>RSS Tutorial</title><link>http://www.w3schools.com/xml/xml_rss.asp</link><description>New RSS tutorial on W3Schools</description></item><item><title>XML Tutorial</title><link>http://www.w3schools.com/xml</link><description>New XML tutorial on W3Schools</description></item></channel></rss>";
            var expected = "{\"title\":\"W3Schools Home Page\",\"link\":\"http://www.w3schools.com\",\"description\":\"Free web building tutorials\",\"items\":[{\"title\":\"RSS Tutorial\",\"link\":\"http://www.w3schools.com/xml/xml_rss.asp\",\"description\":\"New RSS tutorial on W3Schools\"},{\"title\":\"XML Tutorial\",\"link\":\"http://www.w3schools.com/xml\",\"description\":\"New XML tutorial on W3Schools\"}]}";
            var actual = FeedConvertUtils.RssToFeedModel(xml);
            var jsonStringActual = Newtonsoft.Json.JsonConvert.SerializeObject(actual);
            Assert.AreEqual(expected, jsonStringActual);
        }
    }
}
