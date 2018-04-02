using Newtonsoft.Json;
using XamarinMastering.News;
using XamarinMastering.News.Trending;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace XamarinMastering.Helpers
{
    public static class NewsHelper
    {
        public static string CurrentCultureLabel => System.Globalization.CultureInfo.CurrentUICulture.Name;

        public static async Task<List<NewsInformation>> GetByCategoryAsync(NewsCategoryType category)
        {
            try
            {
                throw new Exception();
                List<NewsInformation> results = new List<NewsInformation>();

                string searchUrl = $"https://api.cognitive.microsoft.com/bing/v7.0/news/?Category={category}";

                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Common.CoreConstants.NewsSearchApiKey);

                var uri = new Uri(searchUrl);
                var result = await client.GetStringAsync(uri);
                var newsResult = JsonConvert.DeserializeObject<NewsResult>(result);

                results = (from item in newsResult.value
                           select new NewsInformation()
                           {
                               Title = item.name,
                               Description = item.description,
                               CreatedDate = item.datePublished,
                               ImageUrl = item.image?.thumbnail?.contentUrl,

                           }).ToList();

                return results.Where(w => !string.IsNullOrEmpty(w.ImageUrl)).Take(10).ToList();
            }
            catch (Exception)
            {
                Task<List<NewsInformation>> task = Task.Run(() =>
                {
                    int descriptionCounter = 0, titleCounter = 0;
                    return new List<NewsInformation>
                    {
                        new NewsInformation { Title = $"Trump uses 'no collusion' 7 times in a single Russia answer", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(GetByCategoryAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(GetByCategoryAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(GetByCategoryAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(GetByCategoryAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(GetByCategoryAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(GetByCategoryAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(GetByCategoryAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(GetByCategoryAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" }
                    };
                });
                if (task.Wait(TimeSpan.FromSeconds(10)))
                    return task.Result;
                else
                    return new List<NewsInformation>();
            }
        }

        public static async Task<List<NewsInformation>> GetAsync(string searchQuery)
        {
            try
            {
                throw new Exception();
                List<NewsInformation> results = new List<NewsInformation>();

                string searchUrl = $"https://api.cognitive.microsoft.com/bing/v5.0/news/search?q={searchQuery}&count=10&offset=0&mkt=en-us&safeSearch=Moderate";

                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Common.CoreConstants.NewsSearchApiKey);

                var uri = new Uri(searchUrl);
                var result = await client.GetStringAsync(uri);
                var newsResult = JsonConvert.DeserializeObject<NewsResult>(result);

                results = (from item in newsResult.value
                           select new NewsInformation()
                           {
                               Title = item.name,
                               Description = item.description,
                               CreatedDate = item.datePublished,
                               ImageUrl = item.image?.thumbnail?.contentUrl,

                           }).ToList();

                return results.Where(w => !string.IsNullOrEmpty(w.ImageUrl)).Take(10).ToList();
            }
            catch (Exception)
            {
                Task<List<NewsInformation>> task = Task.Run(() =>
                {
                    int descriptionCounter = 0, titleCounter = 0;
                    return new List<NewsInformation>
                    {
                        new NewsInformation { Title = $"{nameof(GetAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "app" },
                        new NewsInformation { Title = $"{nameof(GetAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "app" },
                        new NewsInformation { Title = $"{nameof(GetAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "app" },
                        new NewsInformation { Title = $"{nameof(GetAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "app" },
                        new NewsInformation { Title = $"{nameof(GetAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "app" },
                        new NewsInformation { Title = $"{nameof(GetAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "app" },
                        new NewsInformation { Title = $"{nameof(GetAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "app" },
                        new NewsInformation { Title = $"{nameof(GetAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "app" },
                        new NewsInformation { Title = $"{nameof(GetAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "app" }
                    };
                });
                if (task.Wait(TimeSpan.FromSeconds(10)))
                    return task.Result;
                else
                    return new List<NewsInformation>();                
            }
        }

        public static async Task<List<NewsInformation>> SearchAsync(string searchQuery)
        {
            try
            {
                List<NewsInformation> results = new List<NewsInformation>();

                string searchUrl = $"https://api.cognitive.microsoft.com/bing/v5.0/news/search?q={searchQuery}&count=10&offset=0&mkt={CurrentCultureLabel}&safeSearch=Moderate";

                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Common.CoreConstants.NewsSearchApiKey);

                var uri = new Uri(searchUrl);
                var result = await client.GetStringAsync(uri);
                var newsResult = JsonConvert.DeserializeObject<NewsResult>(result);

                results = (from item in newsResult.value
                           select new NewsInformation()
                           {
                               Title = item.name,
                               Description = item.description,
                               CreatedDate = item.datePublished,
                               Url = item.url,
                               ImageUrl = item.image?.thumbnail?.contentUrl,
                               Category = item.category + "",

                           }).OrderByDescending(o => o.CreatedDate).ToList();

                return results.Where(w => !string.IsNullOrEmpty(w.ImageUrl)).Take(10).ToList();
            }
            catch (Exception ex)
            {
                Task<List<NewsInformation>> task = Task.Run(() =>
                {
                    int descriptionCounter = 0, titleCounter = 0;
                    return new List<NewsInformation>
                    {
                        new NewsInformation { Title = $"Trump uses 'no collusion' 7 times in a single Russia answer", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(SearchAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(SearchAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(SearchAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(SearchAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(SearchAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(SearchAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(SearchAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(SearchAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" }
                    };
                });
                if (task.Wait(TimeSpan.FromSeconds(10)))
                    return task.Result;
                else
                    return new List<NewsInformation>();
            }
        }

        public async static Task<List<NewsInformation>> GetTrendingAsync()
        {
            try
            {
                throw new Exception();
                List<NewsInformation> results = new List<NewsInformation>();

                string searchUrl = $"https://api.cognitive.microsoft.com/bing/v5.0/news/trendingtopics";

                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Common.CoreConstants.NewsSearchApiKey);

                var uri = new Uri(searchUrl);
                var result = await client.GetStringAsync(uri);
                var newsResult = JsonConvert.DeserializeObject<TrendingNewsResult>(result);

                results = (from item in newsResult.value
                           select new NewsInformation()
                           {
                               Title = item.name,
                               Description = item.query.text,
                               CreatedDate = DateTime.Now,
                               ImageUrl = item.image.url,

                           }).ToList();

                return results.Where(w => !string.IsNullOrEmpty(w.ImageUrl)).Take(10).ToList();
            }
            catch (Exception)
            {
                Task<List<NewsInformation>> task = Task.Run(() =>
                {
                    int descriptionCounter = 0, titleCounter = 0;
                    return new List<NewsInformation>
                    {
                        new NewsInformation { Title = $"{nameof(GetTrendingAsync)} {titleCounter++}", CreatedDate = DateTime.Now.AddHours(-2), Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(GetTrendingAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(GetTrendingAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(GetTrendingAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(GetTrendingAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(GetTrendingAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(GetTrendingAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(GetTrendingAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" },
                        new NewsInformation { Title = $"{nameof(GetTrendingAsync)} {titleCounter++}", CreatedDate = DateTime.Now, Description = $"{nameof(NewsInformation)} {descriptionCounter++}", ImageUrl = "/icon.png" }
                    };
                });
                if (task.Wait(TimeSpan.FromSeconds(20)))
                    return task.Result;
                else
                    return new List<NewsInformation>();                
            }

        }
    }
}
