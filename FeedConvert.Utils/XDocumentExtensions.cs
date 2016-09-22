using System.Xml.Linq;

namespace FeedConvert.Controllers
{
    public static class XDocumentExtensions
    {

        public static string ToSafeString(this XElement el)
        {
            if (el != null)
            {
                return el.Value;
            }
            return string.Empty;
        }

        public static string GetElementValue(this XElement el, string name)
        {
            var ret = "";
            if (el != null)
            {
                ret = el.Element(name).ToSafeString();
            }
            return ret;
        }
    }
}