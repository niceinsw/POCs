using System;

namespace MiscDemo.Models.SitemapModels
{
    public class ArticleSummary
    {
        public string Headline { get; set; }
        public string Url { get; set; }
        public string Abstract { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateAmended { get; set; }
    }
}