using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WPCM.Models.CategoryModels
{

    public class Self
    {
        public string href { get; set; }
    }

    public class Collection
    {
        public string href { get; set; }
    }

    public class About
    {
        public string href { get; set; }
    }

    public class WpPostType
    {
        public string href { get; set; }
    }

    public class Cury
    {
        public string name { get; set; }
        public string href { get; set; }
        public bool templated { get; set; }
    }

    public class Links
    {
        public List<Self> self { get; set; }
        public List<Collection> collection { get; set; }
        public List<About> about { get; set; }
        public List<WpPostType> __invalid_name__wp_post_type { get; set; }
        public List<Cury> curies { get; set; }
    }

    public class CategoryListResponse
    {
        public int id { get; set; }
        public int count { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string taxonomy { get; set; }
        public int parent { get; set; }
        public List<object> meta { get; set; }
        public Links _links { get; set; }
    }
}