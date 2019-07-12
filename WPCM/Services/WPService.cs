using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WPCM.Models;
using WPCM.Models.CategoryModels;

namespace WPCM.Services
{
    public class WPService
    {
        public PostResponse GetPost(int id)
        {
            string url = "http://smbreaking.com/wp-json/wp/v2/posts/";

            var client = new RestClient(url);

            int postId = 16;
            var request = new RestRequest(postId.ToString(), Method.GET);
            
            var res = client.Execute<PostResponse>(request);

            return res.Data;
        }

        public List<CategoryListResponse> GetAllCategories()
        {            
            string url = "http://smbreaking.com/wp-json/wp/v2/categories/";

            var client = new RestClient(url);
                        
            var request = new RestRequest(Method.GET);

            var res = client.Execute<List<CategoryListResponse>>(request);
            
            return res.Data;
        }

        public List<PostResponse> GetCategoryPosts(int id)
        {
            string url = $"http://smbreaking.com/wp-json/wp/v2/posts?categories={id}";
            
            var client = new RestClient(url);

            var request = new RestRequest(Method.GET);

            var res = client.Execute<List<PostResponse>>(request);

            return res.Data;
        }

        //private T CallApi<T>(string endpoint) where T is class
        //{
        //    string url = "http://smbreaking.com/wp-json/wp/v2/posts/";

        //    var client = new RestClient(url);

        //    int postId = 16;
        //    var request = new RestRequest(endpoint, Method.GET);

        //    var res = client.Execute<T>(request);

        //    return res2.Data;
        //}
    }
}