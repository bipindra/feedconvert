using System.Collections.Generic;
using FeedConvert.Controllers;

namespace FeedConvert.Models
{
    public class Feed
    {
        public Feed()
        {
            items = new List<Item>();
            title = string.Empty;
            link = string.Empty;
            description = string.Empty;
        }
        
        public string title { get; set; }
        public string link { get; set; }

        public string description { get; set; }
        public List<Item> items { get; set; }
    }
}