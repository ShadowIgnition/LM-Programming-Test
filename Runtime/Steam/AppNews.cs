using Newtonsoft.Json;
using System.Text;

namespace InfinityHeroes.News.Steam
{
    public struct AppNews
    {
        [JsonConstructor]
        public AppNews(SteamNewsArticle[] newsItems)
        {
            NewsItems = newsItems;
        }

        public SteamNewsArticle[] NewsItems { get; set; }

        public override readonly string ToString()
        {
            StringBuilder sb = new();
            sb.Append(base.ToString());
            foreach (SteamNewsArticle item in NewsItems)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }
    }
}
