using System;
using System.Linq;
using System.Xml.Linq;
using FeedConvert.Controllers;
using FeedConvert.Models;

namespace FeedConvert.Utils
{
    public class FeedConvertUtils
    {
        public static Feed RssToFeedModel(string xml)
        {
            var model = new Feed();
            try
            {
                var doc = XDocument.Parse(xml);
                var channelNodes = doc.Descendants("channel");
                
                {
                    var channelNode = channelNodes.FirstOrDefault();
                    if (channelNode != null)
                    {
                        model.title = channelNode.GetElementValue("title");
                        model.description = channelNode.GetElementValue("description");
                        model.link = channelNode.GetElementValue("link");
                        var elements = channelNode.Elements("item");
                        foreach(var el in elements)
                        {
                            model.items.Add(new Item()
                            {
                                title = el.GetElementValue("title"),
                                description = el.GetElementValue("description"),
                                link = el.GetElementValue("link")
                            });
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            return model;
        }
    }
}